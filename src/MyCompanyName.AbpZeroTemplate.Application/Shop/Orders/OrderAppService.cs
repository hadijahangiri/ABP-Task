using Abp.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Shop.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Localization;
using Abp.UI;
using MyCompanyName.AbpZeroTemplate.Shop.Orders.Dto;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders
{
    [AbpAuthorize(AppPermissions.Pages_Shop_Categories)]
    public class OrderAppService : AbpZeroTemplateAppServiceBase, IOrderAppService
    {
        private readonly IRepository<Order, Guid> _repository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IGuidGenerator _guidGenerator;
        public IEventBus EventBus { get; set; }

        public OrderAppService(IRepository<Order, Guid> repository, IRepository<Product, Guid> productRepository, IGuidGenerator guidGenerator)
        {
            _repository = repository;
            _productRepository = productRepository;
            _guidGenerator = guidGenerator;

            EventBus = NullEventBus.Instance;
        }

        public async Task CreateOrder(CreateOrderInput input)
        {
            var orderId = _guidGenerator.Create();
            var order = new Order(orderId);
            foreach (var item in input.Items)
            {
                var product = await _productRepository.FirstOrDefaultAsync(item.ProductId);
                if (product == null)
                    throw new UserFriendlyException(LocalizationManager.GetString(
                        AbpZeroTemplateConsts.LocalizationSourceName, "NotFoundProductErrorMessage"));

                order.AddItem(new OrderItem(order, product, item.Quantity, item.UnitPrice, product.Discount));
            }

            await _repository.InsertAsync(order);

            await EventBus.TriggerAsync(new OrderCreatedEventData
            {
                Id = orderId,
                Items = order.Items
                     .Select(x => new OrderCreatedEventData.OrderItemAdded
                     {
                         ProductId = x.ProductId,
                         Quantity = x.Quantity,
                         UnitPrice = x.UnitPrice,
                         Discount = x.Discount
                     }).ToList()
            });

        }
    }
}

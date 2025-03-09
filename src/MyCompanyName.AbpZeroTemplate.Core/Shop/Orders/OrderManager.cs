using Abp.Events.Bus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp;
using System.Transactions;
using Abp.Events.Bus;
using MyCompanyName.AbpZeroTemplate.InboxPattern;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders
{
    public class OrderManager : IEventHandler<OrderCreatedEventData>
    {
        private readonly IRepository<Order, Guid> _repository;
        private readonly IRepository<InboxMessage, Guid> _inboxRepository;
        public IEventBus EventBus { get; set; }

        public OrderManager(IRepository<Order, Guid> repository, IRepository<InboxMessage, Guid> inboxRepository)
        {
            _repository = repository;
            _inboxRepository = inboxRepository;
            EventBus = NullEventBus.Instance;
        }

        public void HandleEvent(OrderCreatedEventData eventData)
        {
            var payload = JsonSerializer.Serialize(eventData);
            var inboxMessage = new InboxMessage("", payload);
            _inboxRepository.Insert(inboxMessage);
            //save to inbox
            //using var uow = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew);
            //var order = _repository.FirstOrDefault(eventData.Id);
            ////TODO: process order logic
            //order.Confirm();
            //_repository.Update(order);

            //EventBus.TriggerAsync(new OrderConfirmedEventData
            //{
            //    Id = order.Id
            //});

            //uow.Complete();
        }
    }
}

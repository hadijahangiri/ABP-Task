using Abp.Authorization;
using Abp.Domain.Repositories;
using MyCompanyName.AbpZeroTemplate.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Shop.Products.Dto;
using Abp.Localization;
using Abp.UI;

namespace MyCompanyName.AbpZeroTemplate.Shop.Products
{
    [AbpAuthorize(AppPermissions.Pages_Shop_Categories)]
    public class ProductAppService : AbpZeroTemplateAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, Guid> _repository;

        public ProductAppService(IRepository<Product, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<ProductListDto>> GetProducts(GetProductsInput input)
        {
            var query = _repository
                .GetAll()
                .WhereIf(!input.Name.IsNullOrEmpty(),
                    x => x.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var categories = await query
                .OrderBy(u => u.Name)
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<ProductListDto>(totalCount
                , categories.Select(x => new ProductListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Discount = x.Discount,
                    CreationTime = x.CreationTime
                }).ToList());
        }


        [AbpAuthorize(AppPermissions.Pages_Shop_Products_Create)]
        public async Task CreateProduct(CreateProductInput input)
        {
            var existProduct = await _repository.FirstOrDefaultAsync(x => x.Name == input.Name);
            if (existProduct != null)
                throw new UserFriendlyException(LocalizationManager.GetString(
                    AbpZeroTemplateConsts.LocalizationSourceName, "DuplicateProductErrorMessage"));

            var product = new Product(input.CategoryId, input.Name, input.Price);
            await _repository.InsertAsync(product);
        }
    }
}

using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Shop.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Shop.Products
{
    public interface IProductAppService
    {
        Task<PagedResultDto<ProductListDto>> GetProducts(GetProductsInput input);
        Task CreateProduct(CreateProductInput input);
    }
}

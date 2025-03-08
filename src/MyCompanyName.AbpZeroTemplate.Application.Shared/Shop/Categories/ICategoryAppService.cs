using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.Shop.Categories.Dto;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Dto;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories
{

    public interface ICategoryAppService : IApplicationService
    {
        Task<PagedResultDto<CategoryListDto>> GetCategories(GetCategoriesInput input);
        Task CreateCategory(CreateCategoryInput input);
        //Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto input);

        //Task CreateOrUpdateRole(CreateOrUpdateRoleInput input);

        //Task DeleteRole(EntityDto input);
    }
}

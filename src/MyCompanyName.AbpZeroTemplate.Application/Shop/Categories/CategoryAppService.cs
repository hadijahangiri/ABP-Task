using Abp.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using MyCompanyName.AbpZeroTemplate.Shop.Categories.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.UI;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories
{
    [AbpAuthorize(AppPermissions.Pages_Shop_Categories)]
    public class CategoryAppService : AbpZeroTemplateAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category, Guid> _repository;

        public CategoryAppService(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<CategoryListDto>> GetCategories(GetCategoriesInput input)
        {
            var query = _repository
                .GetAll()
                .WhereIf(!input.Name.IsNullOrEmpty(),
                    x=> x.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var categories = await query
                .OrderBy(u => u.Name)
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<CategoryListDto>(totalCount
            , categories.Select(x => new CategoryListDto
            {
                Id = x.Id,
                Name = x.Name,
                CreationTime = x.CreationTime
            }).ToList());
        }

        [AbpAuthorize(AppPermissions.Pages_Shop_Categories_Create)]
        public async Task CreateCategory(CreateCategoryInput input)
        {
            var existCategory = await _repository.FirstOrDefaultAsync(x => x.Name == input.Name);
            if (existCategory != null)
                throw new UserFriendlyException(LocalizationManager.GetString(
                    AbpZeroTemplateConsts.LocalizationSourceName, "DuplicateCategoryErrorMessage"));

            var category = new Category(input.Name);
            await _repository.InsertAsync(category);
        }

      
    }
}

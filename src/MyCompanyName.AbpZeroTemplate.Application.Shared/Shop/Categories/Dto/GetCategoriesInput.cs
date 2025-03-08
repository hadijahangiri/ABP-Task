using Abp.Runtime.Validation;
using JetBrains.Annotations;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories.Dto;

public class GetCategoriesInput : PagedAndSortedInputDto, IShouldNormalize
{
    [CanBeNull] public string Name { get; set; }
    public void Normalize()
    {
        if (string.IsNullOrEmpty(Sorting))
        {
            Sorting = "name";
        }
    }
}
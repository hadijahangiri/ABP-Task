using Abp.Runtime.Validation;
using JetBrains.Annotations;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.Shop.Products.Dto;

public class GetProductsInput : PagedAndSortedInputDto, IShouldNormalize
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
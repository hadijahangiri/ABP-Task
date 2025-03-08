using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories.Dto;

public class CreateCategoryInput
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}
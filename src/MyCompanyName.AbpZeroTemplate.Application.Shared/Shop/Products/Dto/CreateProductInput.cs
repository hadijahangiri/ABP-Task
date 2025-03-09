using System;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Shop.Products.Dto;

public class CreateProductInput
{
    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    [StringLength(ProductConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [Range(typeof(decimal), ProductConsts.MinPrice, ProductConsts.MaxPrice)]
    public decimal Price { get; set; }

}
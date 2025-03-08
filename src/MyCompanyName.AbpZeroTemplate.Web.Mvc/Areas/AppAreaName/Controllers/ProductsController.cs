using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Shop.Products;
using MyCompanyName.AbpZeroTemplate.Shop.Products.Dto;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Shop.Categories;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Shop.Products;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Controllers;

[Area("AppAreaName")]
[AbpMvcAuthorize(AppPermissions.Pages_Shop_Products)]
public class ProductsController : AbpZeroTemplateControllerBase
{
    private readonly IProductAppService _service;

    public ProductsController(IProductAppService service)
    {
        _service = service;
    }

    public async Task<ActionResult> Index()
    {
        ViewBag.FilterText = Request.Query["filterText"];
        return View();
    }

    [AbpMvcAuthorize(AppPermissions.Pages_Shop_Products_Create)]
    public async Task<PartialViewResult> CreateModal()
    {
        return PartialView("_CreateModal", new CreateProductViewModel());
    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Shop.Categories;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Shop.Categories;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Controllers;

[Area("AppAreaName")]
[AbpMvcAuthorize(AppPermissions.Pages_Shop_Categories)]
public class CategoriesController : AbpZeroTemplateControllerBase
{
    private readonly ICategoryAppService _appService;

    public CategoriesController(ICategoryAppService appService)
    {
        _appService = appService;
    }

    public async Task<ActionResult> Index()
    {
        ViewBag.FilterText = Request.Query["filterText"];
        return View();
    }

    [AbpMvcAuthorize(AppPermissions.Pages_Shop_Categories_Create)]
    public async Task<PartialViewResult> CreateModal()
    {
        return PartialView("_CreateModal", new CreateCategoryViewModel());
    }
}
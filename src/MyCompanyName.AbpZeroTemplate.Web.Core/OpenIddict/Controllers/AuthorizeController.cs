﻿using Abp.AspNetCore.OpenIddict.Claims;
using Abp.AspNetCore.OpenIddict.Controllers;
using Abp.Authorization;
using Abp.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.Authorization.Roles;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.MultiTenancy;
using OpenIddict.Abstractions;

namespace MyCompanyName.AbpZeroTemplate.Web.OpenIddict.Controllers
{
    public class AuthorizeController : AuthorizeController<Tenant, Role, User>
    {
        public AuthorizeController(AbpSignInManager<Tenant, Role, User> signInManager,
            AbpUserManager<Role, User> userManager, IOpenIddictApplicationManager applicationManager,
            IOpenIddictAuthorizationManager authorizationManager, IOpenIddictScopeManager scopeManager,
            IOpenIddictTokenManager tokenManager,
            AbpOpenIddictClaimsPrincipalManager openIddictClaimsPrincipalManager) : base(signInManager, userManager,
            applicationManager, authorizationManager, scopeManager, tokenManager, openIddictClaimsPrincipalManager)
        {
        }
    }
}
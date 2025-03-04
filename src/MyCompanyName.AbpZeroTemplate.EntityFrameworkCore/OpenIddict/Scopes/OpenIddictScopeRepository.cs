using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Scopes;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.OpenIddict.Scopes
{
    public class OpenIddictScopeRepository : EfCoreOpenIddictScopeRepository<AbpZeroTemplateDbContext>
    {
        public OpenIddictScopeRepository(
            IDbContextProvider<AbpZeroTemplateDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
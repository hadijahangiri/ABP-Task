using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Authorizations;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.OpenIddict.Authorizations
{
    public class OpenIddictAuthorizationRepository : EfCoreOpenIddictAuthorizationRepository<AbpZeroTemplateDbContext>
    {
        public OpenIddictAuthorizationRepository(
            IDbContextProvider<AbpZeroTemplateDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
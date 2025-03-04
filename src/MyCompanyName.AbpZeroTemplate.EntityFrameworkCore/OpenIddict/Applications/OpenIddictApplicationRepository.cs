using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Applications;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.OpenIddict.Applications
{
    public class OpenIddictApplicationRepository : EfCoreOpenIddictApplicationRepository<AbpZeroTemplateDbContext>
    {
        public OpenIddictApplicationRepository(
            IDbContextProvider<AbpZeroTemplateDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
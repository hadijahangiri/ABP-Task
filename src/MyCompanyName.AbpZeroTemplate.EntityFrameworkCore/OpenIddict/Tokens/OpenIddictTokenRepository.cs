using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Tokens;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.OpenIddict.Tokens
{
    public class OpenIddictTokenRepository : EfCoreOpenIddictTokenRepository<AbpZeroTemplateDbContext>
    {
        public OpenIddictTokenRepository(
            IDbContextProvider<AbpZeroTemplateDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
namespace MyCompanyName.AbpZeroTemplate.Maui.Services.Tenants
{
    public interface ITenantCustomizationService
    {
        Task<string> GetTenantLogo();
    }
}
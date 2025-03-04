using MyCompanyName.AbpZeroTemplate.Maui.Models.NavigationMenu;

namespace MyCompanyName.AbpZeroTemplate.Maui.Services.Navigation
{
    public interface IMenuProvider
    {
        List<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}
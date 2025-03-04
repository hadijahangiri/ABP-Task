using MyCompanyName.AbpZeroTemplate.Maui.Core.Components;
using MyCompanyName.AbpZeroTemplate.Maui.Pages.Layout;
using MyCompanyName.AbpZeroTemplate.Maui.Services.Account;
using MyCompanyName.AbpZeroTemplate.Maui.Services.Navigation;

namespace MyCompanyName.AbpZeroTemplate.Maui.Pages.MySettings
{
    public partial class Settings : MyCompanyName.AbpZeroTemplateMainLayoutPageComponentBase
    {
        protected IAccountService AccountService { get; set; }
        protected NavMenu NavMenu { get; set; }

        protected INavigationService navigationService { get; set; }
        ChangePasswordModal changePasswordModal;

        public Settings()
        {
            AccountService = Resolve<IAccountService>();
            navigationService = Resolve<INavigationService>();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetPageHeader(L("MySettings"));
        }

        private async Task LogOut()
        {
            await AccountService.LogoutAsync();
            navigationService.NavigateTo(NavigationUrlConsts.Login);
        }

        private async Task OnChangePasswordAsync()
        {
            await changePasswordModal.Hide();
            await Task.Delay(300);
            await LogOut();
        }

        private async Task OnLanguageSwitchAsync()
        {
            await SetPageHeader(L("MySettings"));
            StateHasChanged();
        }

        private async Task ChangePassword()
        {
            await changePasswordModal.Show();
        }

    }
}

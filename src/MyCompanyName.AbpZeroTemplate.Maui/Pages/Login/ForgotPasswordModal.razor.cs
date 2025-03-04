using Microsoft.AspNetCore.Components;
using MyCompanyName.AbpZeroTemplate.Authorization.Accounts;
using MyCompanyName.AbpZeroTemplate.Authorization.Accounts.Dto;
using MyCompanyName.AbpZeroTemplate.Maui.Core;
using MyCompanyName.AbpZeroTemplate.Maui.Core.Components;
using MyCompanyName.AbpZeroTemplate.Maui.Core.Threading;
using MyCompanyName.AbpZeroTemplate.Maui.Models.Login;

namespace MyCompanyName.AbpZeroTemplate.Maui.Pages.Login
{
    public partial class ForgotPasswordModal : ModalBase
    {
        public override string ModalId => "forgot-password-modal";
       
        [Parameter] public EventCallback OnSave { get; set; }
        
        public ForgotPasswordModel ForgotPasswordModel { get; } = new();

        private readonly IAccountAppService _accountAppService;

        public ForgotPasswordModal()
        {
            _accountAppService = Resolve<IAccountAppService>();
        }

        protected virtual async Task Save()
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(
                async () =>
                    await _accountAppService.SendPasswordResetCode(new SendPasswordResetCodeInput { EmailAddress = ForgotPasswordModel.EmailAddress }),
                    async () =>
                    {
                        await OnSave.InvokeAsync();
                    }
                );
            });
        }

        protected virtual async Task Cancel()
        {
            await Hide();
        }
    }
}

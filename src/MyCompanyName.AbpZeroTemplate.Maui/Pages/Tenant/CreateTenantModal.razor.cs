using Abp.ObjectMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyCompanyName.AbpZeroTemplate.Common;
using MyCompanyName.AbpZeroTemplate.Editions.Dto;
using MyCompanyName.AbpZeroTemplate.Maui.Core;
using MyCompanyName.AbpZeroTemplate.Maui.Core.Components;
using MyCompanyName.AbpZeroTemplate.Maui.Core.Extensions;
using MyCompanyName.AbpZeroTemplate.Maui.Core.Threading;
using MyCompanyName.AbpZeroTemplate.Maui.Core.Validations;
using MyCompanyName.AbpZeroTemplate.Maui.Models.Tenants;
using MyCompanyName.AbpZeroTemplate.MultiTenancy;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Dto;

namespace MyCompanyName.AbpZeroTemplate.Maui.Pages.Tenant
{
    public partial class CreateTenantModal : ModalBase
    {
        [Parameter] public EventCallback OnSaveCompleted { get; set; }

        public override string ModalId => "create-tenant-modal";
        
        private ITenantAppService _tenantAppService = Resolve<ITenantAppService>();

        private readonly ICommonLookupAppService _commonLookupAppService = Resolve<ICommonLookupAppService>();

        private CreateTenantModel CreateTenantModel { get; set; } = new()
        {
            IsActive = true
        };
        
        public async Task Open()
        {
            await PopulateEditionsCombobox();
            await Show();
        }

        private async Task PopulateEditionsCombobox()
        {
            var editions = await _commonLookupAppService.GetEditionsForCombobox();
            CreateTenantModel.Editions = editions.Items.ToList();

            CreateTenantModel.Editions.Insert(0, new SubscribableEditionComboboxItemDto(CreateTenantModel.NotAssignedValue,
                $"- {L("NotAssigned")} -", null));
        }

        private async Task CreateTenantAsync()
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(async () =>
                {
                    CreateTenantModel.NormalizeCreateTenantInputModel();

                    await _tenantAppService.CreateTenant(CreateTenantModel);
                }, async () =>
                {
                    await UserDialogsService.AlertSuccess(L("SuccessfullySaved"));
                    await Hide();
                    await OnSaveCompleted.InvokeAsync();
                });
            });
        }

        public override Task Hide()
        {
            CreateTenantModel = new CreateTenantModel()
            {
                IsActive = true,
                Editions = []
            };
            
            return base.Hide();
        }
    }
}
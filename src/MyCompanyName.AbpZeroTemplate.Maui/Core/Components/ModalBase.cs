﻿using MyCompanyName.AbpZeroTemplate.Maui.Services.UI;

namespace MyCompanyName.AbpZeroTemplate.Maui.Core.Components
{
    public abstract class ModalBase : MyCompanyName.AbpZeroTemplateComponentBase
    {
        protected ModalManagerService ModalManager { get; set; }

        public abstract string ModalId { get; }

        public ModalBase()
        {
            ModalManager = Resolve<ModalManagerService>();
        }

        public virtual async Task Show()
        {
            await ModalManager.Show(JS, ModalId);
            StateHasChanged();
        }

        public virtual async Task Hide()
        {
            await ModalManager.Hide(JS, ModalId);
        }
    }
}

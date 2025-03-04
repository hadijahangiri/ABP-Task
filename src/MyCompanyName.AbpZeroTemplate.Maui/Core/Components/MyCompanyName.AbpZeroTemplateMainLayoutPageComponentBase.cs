using MyCompanyName.AbpZeroTemplate.Maui.Services.UI;

namespace MyCompanyName.AbpZeroTemplate.Maui.Core.Components
{
    public class MyCompanyName.AbpZeroTemplateMainLayoutPageComponentBase : MyCompanyName.AbpZeroTemplateComponentBase
    {
        protected PageHeaderService PageHeaderService { get; set; }

        protected DomManipulatorService DomManipulatorService { get; set; }

        public MyCompanyName.AbpZeroTemplateMainLayoutPageComponentBase()
        {
            PageHeaderService = Resolve<PageHeaderService>();
            DomManipulatorService = Resolve<DomManipulatorService>();
        }

        protected async Task SetPageHeader(string title)
        {
            PageHeaderService.Title = title;
            PageHeaderService.ClearButton();
            await DomManipulatorService.ClearModalBackdrop(JS);
        }

        protected async Task SetPageHeader(string title, List<PageHeaderButton> buttons)
        {
            PageHeaderService.Title = title;
            PageHeaderService.SetButtons(buttons);
            await DomManipulatorService.ClearModalBackdrop(JS);
        }
    }
}

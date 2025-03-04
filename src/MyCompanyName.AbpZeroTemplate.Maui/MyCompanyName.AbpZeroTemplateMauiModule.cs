using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCompanyName.AbpZeroTemplate.ApiClient;
using MyCompanyName.AbpZeroTemplate.Maui.Core;

namespace MyCompanyName.AbpZeroTemplate.Maui
{
    [DependsOn(typeof(MyCompanyName.AbpZeroTemplateClientModule), typeof(AbpAutoMapperModule))]
    public class MyCompanyName.AbpZeroTemplateMauiModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.ReplaceService<IApplicationContext, MauiApplicationContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCompanyName.AbpZeroTemplateMauiModule).GetAssembly());
        }
    }
}
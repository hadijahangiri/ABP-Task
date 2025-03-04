using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyCompanyName.AbpZeroTemplate
{
    public class MyCompanyName.AbpZeroTemplateClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCompanyName.AbpZeroTemplateClientModule).GetAssembly());
        }
    }
}

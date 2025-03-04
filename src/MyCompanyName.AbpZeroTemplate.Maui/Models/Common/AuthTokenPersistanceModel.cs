using Abp.AutoMapper;
using MyCompanyName.AbpZeroTemplate.Sessions.Dto;

namespace MyCompanyName.AbpZeroTemplate.Maui.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
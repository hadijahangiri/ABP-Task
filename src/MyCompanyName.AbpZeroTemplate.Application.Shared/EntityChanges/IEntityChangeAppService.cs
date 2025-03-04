using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.EntityChanges.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.EntityChanges
{
    public interface IEntityChangeAppService : IApplicationService
    {
        Task<ListResultDto<EntityAndPropertyChangeListDto>> GetEntityChangesByEntity(GetEntityChangesByEntityInput input);
    }
}

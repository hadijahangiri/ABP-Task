using MyCompanyName.AbpZeroTemplate.Auditing.Dto;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.EntityChanges.Dto;
using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}

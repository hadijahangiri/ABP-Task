using MyCompanyName.AbpZeroTemplate.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.EntityChanges.Dto
{
    public class GetEntityChangesByEntityInput
    {
        public string EntityTypeFullName { get; set; }
        public string EntityId { get; set; }
    }
}

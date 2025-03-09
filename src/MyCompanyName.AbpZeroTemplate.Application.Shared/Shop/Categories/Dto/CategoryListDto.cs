using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.MultiTenancy;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories.Dto
{
    public class CategoryListDto : EntityDto<Guid>, IHasCreationTime
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}

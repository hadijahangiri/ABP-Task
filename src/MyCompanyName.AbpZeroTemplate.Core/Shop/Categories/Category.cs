using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories
{
    public class Category : FullAuditedEntity
    {
        public string Name { get; private set; }

        private Category(){}
        public Category(string name)
        {
            Name = name;
        }

    }
}

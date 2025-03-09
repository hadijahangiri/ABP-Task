using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyCompanyName.AbpZeroTemplate.Shop.Products;

namespace MyCompanyName.AbpZeroTemplate.Shop.Categories
{
    public class Category : FullAuditedEntity<Guid>
    {
        public string Name { get; private set; }
        public virtual IReadOnlyCollection<Product> Products { get; } = new List<Product>();

        public Category(string name)
        {
            Name = name;
        }
    }
}

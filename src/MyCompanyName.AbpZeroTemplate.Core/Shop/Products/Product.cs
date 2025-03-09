using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Values;
using Abp.Domain.Entities;
using MyCompanyName.AbpZeroTemplate.Shop.Categories;

namespace MyCompanyName.AbpZeroTemplate.Shop.Products
{
    public class Product : FullAuditedEntity<Guid>
    {
        public string Name { get; private set; }
        //TODO: use money for price
        public decimal Price { get; private set; }
        //TODO: discount manager
        public decimal? Discount { get; private set; }

        public Guid CategoryId { get; private set; }
        public virtual Category Category { get; set; }

        public Product(Guid categoryId, string name, decimal price)
        {
            CategoryId = categoryId;
            Name = name;
            Price = price;
        }

        public void SetDiscount(decimal discount)
        {
            Discount = discount;
        }
    }
}

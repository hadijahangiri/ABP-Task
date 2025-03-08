using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Values;
using Abp.Domain.Entities;

namespace MyCompanyName.AbpZeroTemplate.Shop.Products
{
    public class Product : FullAuditedEntity
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        //TODO: use money for price
        public decimal Price { get; private set; }
        //TODO: discount manager
        public decimal? Discount { get; private set; }

        public Product(int categoryId, string name, decimal price)
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

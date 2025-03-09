using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders
{
    public sealed class Order : FullAuditedEntity<Guid>
    {
        public OrderStatus Status { get; set; } 

        private readonly List<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public Order(Guid id)
        {
            Id = id;
            Status = OrderStatus.Pending;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void Confirm()
        {
            Status = OrderStatus.Completed;
        }
    }
}

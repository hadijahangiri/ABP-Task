using System;
using System.Collections.Generic;
using Abp.Events.Bus;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders;

public class OrderCreatedEventData : EventData
{
    public Guid Id { get; set; }
    public List<OrderItemAdded> Items { get; set; }

    public class OrderItemAdded
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
    }
}
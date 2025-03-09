using System;
using Abp.Events.Bus;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders;

public class OrderConfirmedEventData : EventData
{
    public Guid Id { get; set; }
}
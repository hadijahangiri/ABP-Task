using System;
using System.Collections.Generic;
using Abp.Domain.Values;
using MyCompanyName.AbpZeroTemplate.Shop.Products;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders;

public class OrderItem : ValueObject
{
    public Guid Id { get; set; }
    public Guid OrderId { get; private set; }
    public virtual Order Order { get; private set; }
    public Guid ProductId { get; private set; }
    public virtual Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal? Discount { get; private set; }

    private OrderItem() { }
    public OrderItem(Order order, Product product, int quantity, decimal unitPrice, decimal? discount)
    {
        OrderId = order.Id;
        ProductId = product.Id;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return OrderId;
        yield return ProductId;
        yield return Quantity;
        yield return UnitPrice;
        yield return Discount;
    }
}
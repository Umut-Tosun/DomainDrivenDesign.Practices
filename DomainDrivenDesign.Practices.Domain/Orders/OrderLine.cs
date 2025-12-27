using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Products;
using DomainDrivenDesign.Practices.Domain.Shared;

namespace DomainDrivenDesign.Practices.Domain.Orders;

public sealed class OrderLine : Entity
{
    public OrderLine(Guid id) : base(id)
    {
    }

    public OrderLine(Guid id,Guid orderId, Order order, Guid productId, Product product, int qantity, Money price) : base(id)
    {
        OrderId = orderId;
        this.order = order;
        ProductId = productId;
        Product = product;
        Qantity = qantity;
        Price = price;
    }

    public Guid OrderId { get;private set; }
    public Order order { get;private set; }
    public Guid ProductId { get;private set; }
    public Product Product { get;private set; }
    public int Qantity { get;private set; }
    public Money Price { get;private set; }
}
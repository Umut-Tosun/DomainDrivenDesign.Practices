using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Products;

namespace DomainDrivenDesign.Practices.Domain.Orders;

public sealed class OrderLine : Entity
{
    public OrderLine(Guid id) : base(id)
    {
    }

    public Guid OrderId { get; set; }
    public Order order { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Qantity { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
}
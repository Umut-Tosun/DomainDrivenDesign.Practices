using DomainDrivenDesign.Practices.Domain.Abstractions;
using static DomainDrivenDesign.Practices.Domain.Orders.Order;

namespace DomainDrivenDesign.Practices.Domain.Orders;

public sealed  class Order : Entity
{
    public Order(Guid id) : base(id)
    {
    }

    public string OrderNumber { get; set; } = default!;  
    public DateTime DateTime { get; set; }
    public OrderStatusEnum Status { get; set; } = default!;
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}

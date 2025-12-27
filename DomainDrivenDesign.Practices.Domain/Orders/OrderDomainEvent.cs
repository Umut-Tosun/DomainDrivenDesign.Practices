using MediatR;

namespace DomainDrivenDesign.Practices.Domain.Orders;

public sealed class OrderDomainEvent : INotification
{
    public Order order { get;}
    public OrderDomainEvent(Order order)
    {
        this.order = order; 
    }
}



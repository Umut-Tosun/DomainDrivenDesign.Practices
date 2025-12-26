using MediatR;

namespace DomainDrivenDesign.Practices.Domain.Orders.Events
{
    public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Sending SMS for Order ID: {notification.order.Id}");
            return Task.CompletedTask;
        }
    }
}

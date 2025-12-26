using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Practices.Domain.Orders.Events
{
    public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Sending email for Order ID: {notification.order.Id}");
            return Task.CompletedTask;

        }
    }
}

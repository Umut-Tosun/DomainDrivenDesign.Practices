using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Practices.Domain.Users.Events
{
    public sealed class UserDomainEvent : INotification
    {
        public User user { get; }
        public UserDomainEvent(User user)
        {
            this.user = user;
        }
    }
    public sealed class SendRegisterMailEvent : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Sending registration email for User ID: {notification.user.Id}");
            return Task.CompletedTask;
        }
    }
}

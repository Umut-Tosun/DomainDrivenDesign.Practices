using MediatR;

namespace DomainDrivenDesign.Practices.Domain.Users.Events
{
    public sealed class SendRegisterMailEvent : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Sending registration email for User ID: {notification.user.Id}");
            return Task.CompletedTask;
        }
    }
}

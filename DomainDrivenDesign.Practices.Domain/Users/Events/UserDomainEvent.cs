using MediatR;

namespace DomainDrivenDesign.Practices.Domain.Users.Events;

public sealed class UserDomainEvent : INotification
{
    public User user { get; }
    public UserDomainEvent(User user)
    {
        this.user = user;
    }
}

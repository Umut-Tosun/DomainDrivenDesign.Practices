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
}

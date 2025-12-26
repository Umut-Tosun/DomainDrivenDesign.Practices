using BenchmarkDotNet.Running;
using MediatR;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Guid guid = Guid.NewGuid();
            // A a1 = new(guid);
            // A a2 = new(guid);
            // Console.WriteLine(a1.Equals(a2));

            // BenchmarkRunner.Run<BenchmakService>();
          

           

           

            //DomainEventsDispatcher.Dispatch(order.DomainEvents);

        }
    }
    public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent>
    {
        public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"StockUpdateHandler tetiklendi. OrderId: {notification.Id}");
            return Task.CompletedTask;
        }
    }
    public class SendMailHandler : INotificationHandler<OrderCompletedEvent>
    {
        public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"SendMailHandler tetiklendi. OrderId: {notification.Id}");
            return Task.CompletedTask;
        }
    }
    public class SendSmsHandler : INotificationHandler<OrderCompletedEvent>
    {
        public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"SendSmsHandler tetiklendi. OrderId: {notification.Id}");
            return Task.CompletedTask;
        }
    }
    public class OrderCompletedEvent : INotification
    {
        public int Id { get; }
        public OrderCompletedEvent(int orderId)
        {
            Id = orderId;
        }
    }
    public class Order
    {
        private readonly IMediator  mediator;

        public Order(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public int Id { get; set; }
        public string? ProductName { get; set; }
        public List<IDomainEvent> DomainEvents { get; } = new();
        public void CreateOrder(int id, string productName)
        {
            Id = id;
            ProductName = productName;

            mediator.Publish(new OrderCompletedEvent(id));

            //bazi islemlerin tetiklenmesi
            //DomainEvents.Add(new OrderCreatedEvent(id));
        }
    }
    public static class DomainEventsDispatcher
    {
        public static void Dispatch(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                switch (domainEvent)
                {
                    case OrderCreatedEvent orderCreatedEvent:
                        Console.WriteLine($"Order Created Event Tetiklendi. OrderId: {orderCreatedEvent.OrderId}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public interface IDomainEvent
    {

    }
    public class OrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get; }
        public OrderCreatedEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
    public abstract class Entity
    {
        public Guid Id { get; init; }
        public Entity(Guid id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Entity entity) return false;
            if (obj.GetType() != GetType()) return false;

            return entity.Id == Id;
        }
    }
    public sealed class A : Entity
    {
        public A(Guid id) : base(id)
        {
        }
    }
}

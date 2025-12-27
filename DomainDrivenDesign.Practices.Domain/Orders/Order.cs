using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Shared;
using static DomainDrivenDesign.Practices.Domain.Orders.Order;

namespace DomainDrivenDesign.Practices.Domain.Orders;

public sealed  class Order : Entity
{
    public Order(Guid id) : base(id)
    {
    }

    public Order(Guid id, string orderNumber, DateTime dateTime, OrderStatusEnum status) : base(id)
    {
        Id = id;
        OrderNumber = orderNumber;
        DateTime = dateTime;
        Status = status;
    }

    public string OrderNumber { get; private set; } = default!;
    public DateTime DateTime { get; private set; }
    public OrderStatusEnum Status { get; private set; } = default!;
    public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();


    public void CreateOrder(List<CreateOrderDto> createOrderDtos)
    {
        foreach (var dto in createOrderDtos)
        {
            if(dto.Quantity < 1)
                throw new ArgumentException("Quantity must be at least 1.", nameof(dto.Quantity));

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.", nameof(dto.Amount));
           

            var orderLine = new OrderLine(
                Guid.NewGuid(),
                this.Id,
                this,
                dto.ProductId,
                null!, // Product should be fetched from repository
                dto.Quantity,
                new(dto.Amount,Currency.FromCode(dto.Currency))
            );
            OrderLines.Add(orderLine);
        }

    }
    public void RemoveOrderLine(Guid orderLineId)
    {
        var orderLine = OrderLines.FirstOrDefault(ol => ol.Id == orderLineId);
        if (orderLine != null)
        {
            OrderLines.Remove(orderLine);
        }
        throw new ArgumentException("Order line not found.", nameof(orderLineId));
    }
}



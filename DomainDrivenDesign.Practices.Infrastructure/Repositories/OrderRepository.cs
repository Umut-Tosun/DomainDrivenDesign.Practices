using DomainDrivenDesign.Practices.Domain.Orders;
using DomainDrivenDesign.Practices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Practices.Infrastructure.Repositories;

internal class OrderRepository(ApplicationDbContext applicationDbContext) : IOrderRepository
{

    public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos)
    {
        Order order = new Order(
            Guid.NewGuid(),
            "1",
            DateTime.Now,
            OrderStatusEnum.AwaitingOrder
        );

        order.CreateOrder(createOrderDtos);

        await applicationDbContext.orders.AddAsync(order);
        return order;

    }

    public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return applicationDbContext.orders.ToListAsync(cancellationToken);
    }
}

using DomainDrivenDesign.Practices.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Orders.GetAllOrder;

internal sealed class GetAllOrderQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetAllOrderQuery, List<Order>>
{
    public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetAllAsync(cancellationToken);
    }
}
using DomainDrivenDesign.Practices.Domain.Orders;
using MediatR;
using static DomainDrivenDesign.Practices.Domain.Orders.Order;

namespace DomainDrivenDesign.Practices.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;

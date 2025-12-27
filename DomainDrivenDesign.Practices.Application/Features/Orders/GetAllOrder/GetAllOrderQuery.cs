using DomainDrivenDesign.Practices.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Orders.GetAllOrder;

public sealed record GetAllOrderQuery() : IRequest<List<Order>>;

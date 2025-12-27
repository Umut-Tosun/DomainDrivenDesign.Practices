using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork,IMediator mediator) : IRequestHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
         var order =  await orderRepository.CreateAsync(request.CreateOrderDtos);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await mediator.Publish(new OrderDomainEvent(order));

    }
}


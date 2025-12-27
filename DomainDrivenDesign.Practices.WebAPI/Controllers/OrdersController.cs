using DomainDrivenDesign.Practices.Application.Features.Orders.CreateOrder;
using DomainDrivenDesign.Practices.Application.Features.Orders.GetAllOrder;
using DomainDrivenDesign.Practices.Application.Features.Users.CreateUser;
using DomainDrivenDesign.Practices.Application.Features.Users.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Practices.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var result = mediator.Send(command, cancellationToken);
            return Ok(new { message = "Siparis başarıyla oluşturuldu" });
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}

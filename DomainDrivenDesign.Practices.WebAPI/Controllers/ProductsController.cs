using DomainDrivenDesign.Practices.Application.Features.Products.CreateProduct;
using DomainDrivenDesign.Practices.Application.Features.Products.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Practices.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = mediator.Send(command, cancellationToken);
        return Ok(new { message = "Urun başarıyla oluşturuldu" });
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}

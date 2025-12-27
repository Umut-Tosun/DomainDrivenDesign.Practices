using DomainDrivenDesign.Practices.Application.Features.Categories.CreateCategory;
using DomainDrivenDesign.Practices.Application.Features.Categories.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Practices.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator mediator;

    public CategoriesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}

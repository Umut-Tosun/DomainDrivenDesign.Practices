using DomainDrivenDesign.Practices.Application.Features.Users.CreateUser;
using DomainDrivenDesign.Practices.Application.Features.Users.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Practices.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command,CancellationToken cancellationToken)
    {
        var result = mediator.Send(command,cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllUserQuery request,CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}

using HousingMaroc.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingMaroc.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost("signin")]
    public async Task<ActionResult<string>> SignIn(SignInUserCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(token);
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUp(AddUserCommand command)
    {
        await _mediator.Send(command);
        
        return Ok();
    }
}

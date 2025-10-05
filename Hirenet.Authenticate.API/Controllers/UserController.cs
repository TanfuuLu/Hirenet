using Hirenet.Authenticate.Application.DTOs;
using Hirenet.Authenticate.Application.Mediator.Commands;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirenet.Authenticate.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
	private readonly IMediator mediator;	
	public UserController(IMediator mediator) {
		this.mediator = mediator;
	}
	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] CreateUserDTO item) {
		var command = new CreateUserCommand(item);
		var result = await mediator.Send(command);
		return Ok(result);
	}
}

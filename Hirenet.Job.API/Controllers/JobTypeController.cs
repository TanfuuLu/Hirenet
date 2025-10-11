using Hirenet.Job.Application.DTOs;
using Hirenet.Job.Application.Mediator.Commands;
using Hirenet.Job.Application.Mediator.Queries;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirenet.Job.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class JobTypeController : ControllerBase {
	private readonly IMediator mediator;

	public JobTypeController(IMediator mediator) {
		this.mediator = mediator;
	}
	[HttpGet]
	public IActionResult Get() {
		return Ok("JobType API running");
	}
	[HttpPost("create-jobtype")]
	public async Task<IActionResult> CreateJobType(ModifyJobType item) {
		var command = new CreateJobTypeCommand(item);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpDelete("delete-jobtype/{id:int}")]
	public async Task<IActionResult> DeleteJobType([FromRoute] int id) {
		var command = new DeleteJobTypeCommand(id);
		var result = await mediator.Send(command);
		return Ok(result);

	}
	[HttpGet("getlist-jobtype")]
	public async Task<IActionResult> GetListJobType() {
		var query = new GetListJobTypeQuery();
		var result = await mediator.Send(query);
		return Ok(result);
	}
	
}

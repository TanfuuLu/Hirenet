using Hirenet.Job.Application.DTOs;
using Hirenet.Job.Application.Mediator.Commands;
using Hirenet.Job.Application.Mediator.Queries;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirenet.Job.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase {
	private readonly IMediator mediator;

    public JobController(IMediator mediator) {
	  this.mediator = mediator;
    }
	[HttpGet("")]
	public async Task<IActionResult> Get() {
		return Ok("Job Service is running");
	}
	[HttpPost("create")]
	public async Task<IActionResult> CreateJob([FromBody] CreateJobDTO item) {
		var command = new CreateJobCommand(item);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpPut("update")]
	public async Task<IActionResult> UpdateJob( [FromBody] UpdateJobDTO item) {

		var command = new UpdateJobCommand(item);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> DeleteJob(int id) {
		var command = new DeleteJobCommand(id);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpGet("list-job")]
	public async Task<IActionResult> GetListJob() {
		var query = new GetListJobQuery();
		var result = await mediator.Send(query);
		return Ok(result);
	}
	[HttpGet("job/{id}")]
	public async Task<IActionResult> GetJobByID(int id) {
		var query = new GetJobByID(id);
		var result = await mediator.Send(query);
		return Ok(result);
	}
	[HttpGet("get-by-filter")]
	public async Task<IActionResult> GetListJobByFilter([FromQuery] string? companyName, [FromQuery] string? jobType) {
		var query = new GetListJobByFilter(companyName, jobType);
		var result = await mediator.Send(query);
		return Ok(result);
	}

}

using Hirenet.Contract.Application.Cqrs.Milestones.Commands;
using Hirenet.Contract.Application.Cqrs.Milestones.Queries;
using Hirenet.Contract.Application.DTOs;
using Hirenet.Contract.Application.DTOs.MilestoneDTOs;
using Hirenet.Contract.Domain.Models;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirenet.Contract.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MilestoneController : ControllerBase {
	private readonly IMediator mediator;
	private readonly IWebHostEnvironment env;

	public MilestoneController(IMediator mediator, IWebHostEnvironment env) {
		this.mediator = mediator;
		this.env = env;
	}
	#region FileUpload
	[HttpPost("upload")]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult> Upload([FromForm] MilestoneFileUploadDTO fileUpload) {
		if (fileUpload.File == null || fileUpload.File.Length == 0) {
			return BadRequest("no file upload");
		}
		var dtoModel = new MilestoneFileUploadDTO();
		var rootPath = @"E:\Hirenet\Hirenet\uploadsfile";
		dtoModel.File = fileUpload.File;
		dtoModel.rootPath = rootPath;
		dtoModel.MilestoneId = 1;
		var command = new UploadMilestoneFileCommand(dtoModel);

		var resultFile = await mediator.Send(command);
		return Ok(resultFile);
	}
	[HttpGet("getfiles/{milestoneId:int}")]
	public async Task<IActionResult> GetFiles([FromQuery] int milestoneId) {
		var query = new GetFileQuery(milestoneId);

		var files = await mediator.Send(query);
		return Ok(files);
	}
	#endregion

	#region Milestone Function
	[HttpPost("create-milestone")]
	public async Task<IActionResult> CreateMilestone([FromBody] CreateMilestoneDTO model) {
		var command = new CreateMilestoneCommand(model);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpPut("update-milestone/{milestoneId:int}")]
	public async Task<IActionResult> UpdateMilestone([FromBody] UpdateMilestoneDTO model, [FromRoute] int milestoneId) {
		model.MilestoneId = milestoneId;
		var command = new UpdateMilestoneCommand(model);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpPut("update-milestone-status/{milestoneId:int}")]
	public async Task<IActionResult> UpdateMilestoneStatus([FromBody] UpdateStatusMilestoneDTO model, [FromRoute] int milestoneId) {
		model.MilestoneId = milestoneId;
		var command = new UpdateMilestoneStatusCommand(model);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpDelete("delete-milestone/{milestoneId:int}")]
	public async Task<IActionResult> DeleteMilestone([FromRoute] int milestoneId) {
		var command = new DeleteMilestoneCommand(milestoneId);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpGet("get-all-milestone/{contractId:int}")]	
	public async Task<IActionResult> GetAllMilestoneByContractId([FromRoute] int contractId) {
		var query = new GetAllMilestoneByContractIdQuery(contractId);
		var result = await mediator.Send(query);
		return Ok(result);
	}
	[HttpGet("get-milestone-by-id/{milestoneId:int}")]
	public async Task<IActionResult> GetMilestoneById([FromRoute] int milestoneId) {
		var query = new GetMilestoneByIdQuery(milestoneId);
		var result = await mediator.Send(query);
		return Ok(result);
	}
	#endregion
}

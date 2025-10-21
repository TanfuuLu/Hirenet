using Hirenet.Contract.Application.Cqrs.Commands;
using Hirenet.Contract.Application.Cqrs.Queries;
using Hirenet.Contract.Application.DTOs;
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

    [HttpPost("upload")]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult > Upload([FromForm] MilestoneFileUploadDTO fileUpload ) {
		if(fileUpload.File == null || fileUpload.File.Length == 0) {
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
	public async Task<IActionResult> GetFiles([FromQuery]int milestoneId) {
		var query = new GetFileQuery(milestoneId);
		
		var files = await mediator.Send(query);
		return Ok(files);
	}
}

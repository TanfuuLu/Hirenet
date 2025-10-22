using Hirenet.Contract.Application.Cqrs.Contracts.Commands;
using Hirenet.Contract.Application.Cqrs.Contracts.Queries;
using Hirenet.Contract.Application.DTOs.ContractsDTOs;
using Hirenet.Contract.Domain.Enums;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirenet.Contract.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase {
	private readonly IMediator mediator;

	public ContractController(IMediator mediator) {
		this.mediator = mediator;
	}

	[HttpPost("create-contract")]
	public async Task<IActionResult> CreateContract([FromBody] CreateContractDTO model) {
		var command = new CreateContractCommand(model);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpPut("update-contract-status/{contractId:int}")]
	public async Task<IActionResult> UpdateContractStatus([FromBody] ContractStatus modelStatus, [FromRoute] int contractId) {
		var model = new UpdateStatusContractDTO {
			ContractId = contractId,
			ContractStatus = modelStatus
		};
		var command = new UpdateStatusContractCommand(model);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpPut("update-milestone-contract/{contractId:int}")]
	public async Task<IActionResult> UpdateMilestoneContract([FromBody] List<int> milestoneList, [FromRoute] int contractId) {
		var model = new UpdateMilestoneContractDTO {
			ContractId = contractId,
			MilestonesId = milestoneList
		};
		var command = new UpdateMilestoneContractCommand(model);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpGet("get-contract-by-owner/{ownerId}")]
	public async Task<IActionResult> GetContractByOwnerId([FromRoute] string ownerId) {
		var query = new GetContractByOnwerIdQuery(ownerId);
		var result = await mediator.Send(query);
		return Ok(result);
	}
	[HttpGet("get-contract-by-id/{contractId:int}")]
	public async Task<IActionResult> GetContractById([FromRoute] int contractId) {
		var query = new GetContractByIdQuery(contractId);
		var result = await mediator.Send(query);
		return Ok(result);
	}
	[HttpDelete("delete-contract/{contractId:int}")]	
	public async Task<IActionResult> DeleteContract([FromRoute] int contractId) {
		var command = new DeleteContractByIdCommand(contractId);
		var result = await mediator.Send(command);
		return Ok(result);
	}
}

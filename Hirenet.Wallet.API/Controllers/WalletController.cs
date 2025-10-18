using Hirenet.Wallet.Application.Cqrs.Commands;
using Hirenet.Wallet.Application.Cqrs.Queries;
using Hirenet.Wallet.Application.DTOs;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirenet.Wallet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WalletController : ControllerBase {
	private readonly IMediator mediator;

    public WalletController(IMediator mediator) {
	  this.mediator = mediator;
	}
	[HttpPost("create-wallet")]
	public async Task<IActionResult> CreateUserWallet([FromBody] CreateWalletDTO dtoModel) {
		var command = new CreateWalletCommand(dtoModel);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpGet("get-wallet-infor/{userId}")]
	public async Task<IActionResult> GetWalletInformation([FromRoute]string userId) {
		var query = new GetWalletInformationQuery(userId);
		var result = await mediator.Send(query);
		return Ok(result);
	}
	[HttpPut("update-wallet")]
	public async Task<IActionResult> UpdateWalletBalance([FromBody] UpdateWalletDTO dtoModel) {
		var command = new UpdateWalletCommand(dtoModel);
		var result = await mediator.Send(command);
		return Ok(result);
	}
	[HttpDelete("delete-wallet/{userId}")]
	public async Task<IActionResult> Delete([FromRoute] string userId) {
		var command = new DeleteWalletCommand(userId);
		var result = await mediator.Send(command);
		return Ok(result);
	}
}

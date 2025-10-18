using Hirenet.Wallet.Application.Cqrs.Commands;
using Hirenet.Wallet.Application.Interfaces;
using Hirenet.Wallet.Domain.Models;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Cqrs.Handlers;
public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, UserWallet> {
	private readonly IWalletRepository walletRepository;
	private readonly IMapper mapper;

	public async ValueTask<UserWallet> Handle(CreateWalletCommand request, CancellationToken cancellationToken) {
		var mappedItem = mapper.Map<UserWallet>(request.model);
		var result = await walletRepository.CreateUserWallet(mappedItem);
		return result;
    }
}

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
public class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand, UserWallet> {
	private readonly IWalletRepository walletRepository;
		private readonly IMapper mapper;

    public UpdateWalletHandler(IWalletRepository walletRepository, IMapper mapper) {
	  this.walletRepository = walletRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<UserWallet> Handle(UpdateWalletCommand request, CancellationToken cancellationToken) {

		var result = await walletRepository.UpdateUserWallet(request.model.AvailableBalance, request.model.EscrowBalance,  request.model.UserId);
		return result;
    }
}

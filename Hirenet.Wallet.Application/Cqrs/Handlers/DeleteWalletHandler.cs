using Hirenet.Wallet.Application.Cqrs.Commands;
using Hirenet.Wallet.Application.Interfaces;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Cqrs.Handlers;
public class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand, bool> {
	private readonly IWalletRepository walletRepository;

    public DeleteWalletHandler(IWalletRepository walletRepository) {
	  this.walletRepository = walletRepository;
    }

    public async ValueTask<bool> Handle(DeleteWalletCommand request, CancellationToken cancellationToken) {
		var result = await walletRepository.DeleteUserWallet(request.userId);
		return result;
    }
}

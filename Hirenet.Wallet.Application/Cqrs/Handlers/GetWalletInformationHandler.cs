using Hirenet.Wallet.Application.Cqrs.Queries;
using Hirenet.Wallet.Application.Interfaces;
using Hirenet.Wallet.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Cqrs.Handlers;
public class GetWalletInformationHandler : IRequestHandler<GetWalletInformationQuery, UserWallet> {
	private readonly IWalletRepository walletRepository;

    public GetWalletInformationHandler(IWalletRepository walletRepository) {
	  this.walletRepository = walletRepository;
    }

    public async ValueTask<UserWallet> Handle(GetWalletInformationQuery request, CancellationToken cancellationToken) {
		var result = await walletRepository.GetWalletInformation(request.userId);
		return result;
    }
}

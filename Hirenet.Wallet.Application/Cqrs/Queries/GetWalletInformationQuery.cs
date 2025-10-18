using Hirenet.Wallet.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Cqrs.Queries;
public record  GetWalletInformationQuery(string userId) :IRequest<UserWallet> {
}

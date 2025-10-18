using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Cqrs.Commands;
public record DeleteWalletCommand(string userId): IRequest<bool>;

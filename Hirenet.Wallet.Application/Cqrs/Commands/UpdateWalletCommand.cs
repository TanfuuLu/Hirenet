using Hirenet.Wallet.Application.DTOs;
using Hirenet.Wallet.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Cqrs.Commands;
public record UpdateWalletCommand(UpdateWalletDTO model): IRequest<UserWallet>; 
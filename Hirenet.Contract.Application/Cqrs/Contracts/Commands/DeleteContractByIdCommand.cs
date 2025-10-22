using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Contracts.Commands;
public record DeleteContractByIdCommand(int contractId) : IRequest<bool> {
}

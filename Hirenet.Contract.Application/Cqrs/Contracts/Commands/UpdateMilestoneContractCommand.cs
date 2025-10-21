using Hirenet.Contract.Application.DTOs.ContractsDTOs;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Contracts.Commands;
public record UpdateMilestoneContractCommand(UpdateMilestoneContractDTO model): IRequest<JobContract> {

}

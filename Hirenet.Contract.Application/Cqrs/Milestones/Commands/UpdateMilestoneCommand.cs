using Hirenet.Contract.Application.DTOs.MilestoneDTOs;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Milestones.Commands;
public record UpdateMilestoneCommand(UpdateMilestoneDTO model) : IRequest<Milestone>  {
}
public record UpdateMilestoneStatusCommand(UpdateStatusMilestoneDTO model) : IRequest<Milestone> {
}
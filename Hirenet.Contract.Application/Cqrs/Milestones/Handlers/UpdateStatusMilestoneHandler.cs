using Hirenet.Contract.Application.Cqrs.Milestones.Commands;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Milestones.Handlers;
public class UpdateStatusMilestoneHandler : IRequestHandler<UpdateMilestoneStatusCommand, Milestone> {
    private readonly IMilestoneRepository milestoneRepository;
	private readonly IMapper mapper;

    public UpdateStatusMilestoneHandler(IMilestoneRepository milestoneRepository, IMapper mapper) {
	  this.milestoneRepository = milestoneRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<Milestone> Handle(UpdateMilestoneStatusCommand request, CancellationToken cancellationToken) {
		var itemDomain = mapper.Map<Milestone>(request.model);
		var result = await milestoneRepository.UpdateMilestoneStatusAsync(request.model.MilestoneId, itemDomain.MilestoneStatus );
		return result;
	}
}

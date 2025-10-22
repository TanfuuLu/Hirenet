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
public class UpdateMilestoneHandler : IRequestHandler<UpdateMilestoneCommand, Milestone> {
	private readonly IMapper mapper;
	private readonly IMilestoneRepository milestoneRepository;

    public UpdateMilestoneHandler(IMapper mapper, IMilestoneRepository milestoneRepository) {
	  this.mapper = mapper;
	  this.milestoneRepository = milestoneRepository;
    }

    public async ValueTask<Milestone> Handle(UpdateMilestoneCommand request, CancellationToken cancellationToken) {
		var milestoneDomain = mapper.Map<Milestone>(request.model);
		var result = await milestoneRepository.UpdateMilestoneAsync(milestoneDomain, request.model.MilestoneId);
		return result;
    }
}

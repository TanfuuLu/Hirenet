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
public class CreateMilestoneHandler : IRequestHandler<CreateMilestoneCommand, Milestone> {
	private readonly IMilestoneRepository milestoneRepository;
	private readonly IMapper mapper;

    public CreateMilestoneHandler(IMilestoneRepository milestoneRepository, IMapper mapper) {
	  this.milestoneRepository = milestoneRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<Milestone> Handle(CreateMilestoneCommand request, CancellationToken cancellationToken) {
		var itemDomain = mapper.Map<Milestone>(request.model);
		var result = await milestoneRepository.CreateMilestoneAsync(itemDomain);
		return result;
	}
}

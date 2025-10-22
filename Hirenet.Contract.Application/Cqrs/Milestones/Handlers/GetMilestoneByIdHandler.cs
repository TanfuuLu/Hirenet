using Hirenet.Contract.Application.Cqrs.Milestones.Queries;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Milestones.Handlers;
public class GetMilestoneByIdHandler : IRequestHandler<GetMilestoneByIdQuery, Milestone> {
	private readonly IMilestoneRepository milestoneRepository;

	public GetMilestoneByIdHandler(IMilestoneRepository milestoneRepository) {
		this.milestoneRepository = milestoneRepository;
	}

	public async ValueTask<Milestone> Handle(GetMilestoneByIdQuery request, CancellationToken cancellationToken) {
		var result = await milestoneRepository.GetMilestonesByIdAsync(request.milestoneId);
		return result;
	}
}

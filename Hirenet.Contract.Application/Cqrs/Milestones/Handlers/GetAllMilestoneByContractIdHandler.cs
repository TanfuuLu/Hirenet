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
public class GetAllMilestoneByContractIdHandler : IRequestHandler<GetAllMilestoneByContractIdQuery, ICollection<Milestone>> {
	private readonly IMilestoneRepository milestoneRepository;

    public GetAllMilestoneByContractIdHandler(IMilestoneRepository milestoneRepository) {
	  this.milestoneRepository = milestoneRepository;
    }

    public async ValueTask<ICollection<Milestone>> Handle(GetAllMilestoneByContractIdQuery request, CancellationToken cancellationToken) {
	  var result = await milestoneRepository.GetMilestonesByContractIdAsync(request.contractId);
		return result;
	}
}

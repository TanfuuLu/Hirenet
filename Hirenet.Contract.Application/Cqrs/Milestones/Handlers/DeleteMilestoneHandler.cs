using Hirenet.Contract.Application.Cqrs.Milestones.Commands;
using Hirenet.Contract.Application.Interfaces;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Milestones.Handlers;
public class DeleteMilestoneHandler : IRequestHandler<DeleteMilestoneCommand, bool> {
	private readonly IMilestoneRepository milestoneRepository;

	public DeleteMilestoneHandler(IMilestoneRepository milestoneRepository) {
		this.milestoneRepository = milestoneRepository;
	}

	public async ValueTask<bool> Handle(DeleteMilestoneCommand request, CancellationToken cancellationToken) {
		var result = await milestoneRepository.DeleteMilestoneAsync(request.milestoneId);
		return result;
	}
}

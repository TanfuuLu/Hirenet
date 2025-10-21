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
public class GetFileHandler : IRequestHandler<GetFileQuery, IEnumerable<MilestoneFile>> {
	private readonly IMilestoneFileRepository repository;

	public GetFileHandler(IMilestoneFileRepository repository) {
		this.repository = repository;
	}

	public async ValueTask<IEnumerable<MilestoneFile>> Handle(GetFileQuery request, CancellationToken cancellationToken) {
		var result = await repository.GetFilesByMilestoneAsync(request.milestoneId);
		return result;

	}
}

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
public class GetAllMilestoneFileHandler : IRequestHandler<GetAllMilestoneFileQuery, ICollection<MilestoneFile>>{
	private readonly IMilestoneFileRepository milestoneFileRepository;
	public GetAllMilestoneFileHandler(IMilestoneFileRepository milestoneFileRepository) {
		this.milestoneFileRepository = milestoneFileRepository;
	}
	public async ValueTask<ICollection<MilestoneFile>> Handle(GetAllMilestoneFileQuery request, CancellationToken cancellationToken) {
		var result = await milestoneFileRepository.GetAllMilestoneFileAsync(request.milestoneId);
		return result;
	}
}

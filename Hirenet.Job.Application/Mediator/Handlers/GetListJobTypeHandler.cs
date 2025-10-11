using Hirenet.Job.Application.Interfaces;
using Hirenet.Job.Application.Mediator.Queries;
using Hirenet.Job.Domain;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Handlers;
public class GetListJobTypeHandler : IRequestHandler<GetListJobTypeQuery, List<JobType>> {
	private readonly IJobTypeRepository jobTypeRepository;

    public GetListJobTypeHandler(IJobTypeRepository jobTypeRepository) {
	  this.jobTypeRepository = jobTypeRepository;
    }

    public async ValueTask<List<JobType>> Handle(GetListJobTypeQuery request, CancellationToken cancellationToken) {
		var listItem = await jobTypeRepository.GetAllJobTypes();
		return listItem;
    }
}

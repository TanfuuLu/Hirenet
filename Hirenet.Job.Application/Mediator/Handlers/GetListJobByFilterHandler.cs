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
public class GetListJobByFilterHandler : IRequestHandler<GetListJobByFilter, List<JobModel>> {
	private readonly IJobRepository jobRepository;
	public GetListJobByFilterHandler(IJobRepository jobRepository) {
	  this.jobRepository = jobRepository;
	}
	public async ValueTask<List<JobModel>> Handle(GetListJobByFilter request, CancellationToken cancellationToken) {
	  var result = await jobRepository.GetJobsByFilterAsync(request.companyName, request.jobType);
		return result;
	}
}

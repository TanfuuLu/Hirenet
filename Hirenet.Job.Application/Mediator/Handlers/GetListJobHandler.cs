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
public class GetListJobHandler : IRequestHandler<GetListJobQuery, List<JobModel>> {
	private readonly IJobRepository jobRepository;
	public GetListJobHandler(IJobRepository jobRepository) {
	  this.jobRepository = jobRepository;
	}
	public async ValueTask<List<JobModel>> Handle(GetListJobQuery request, CancellationToken cancellationToken) {
	  var result = await jobRepository.GetAllJobsAsync();
		return result;
	}
}

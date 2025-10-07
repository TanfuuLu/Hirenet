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
public class GetJobByIdHandler : IRequestHandler<GetJobByID, JobModel> {
	private readonly IJobRepository jobRepository;

	public GetJobByIdHandler(IJobRepository jobRepository) {
		this.jobRepository = jobRepository;
	}

	public async ValueTask<JobModel> Handle(GetJobByID request, CancellationToken cancellationToken) {
		var itemReturn = await jobRepository.GetJobByIdAsync(request.jobId);
		if (itemReturn != null) {
			return itemReturn;
		}
		else {
			throw new Exception("Job not found");
		}
	}
}

using Hirenet.Job.Application.Interfaces;
using Hirenet.Job.Application.Mediator.Commands;
using Hirenet.Job.Domain;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Handlers;
public class CreateJobHandler : IRequestHandler<CreateJobCommand, JobModel> {
	private readonly IJobRepository jobRepository;
	private readonly IMapper mapper;

	public CreateJobHandler(IJobRepository jobRepository, IMapper mapper) {
		this.jobRepository = jobRepository;
		this.mapper = mapper;
	}

	public async ValueTask<JobModel> Handle(CreateJobCommand request, CancellationToken cancellationToken) {
		var jobDomain = mapper.Map<JobModel>(request.model);
		var createdJob = await jobRepository.AddJobAsync(jobDomain);
		if (createdJob != null) {
			return createdJob;
		}
		else {
			throw new Exception("Create job failed");
		}
	}
}

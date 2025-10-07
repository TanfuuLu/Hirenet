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
public class UpdateJobHandler : IRequestHandler<UpdateJobCommand, JobModel> {
	private readonly IJobRepository jobRepository;
	private readonly IMapper mapper;

    public UpdateJobHandler(IJobRepository jobRepository, IMapper mapper) {
	  this.jobRepository = jobRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<JobModel> Handle(UpdateJobCommand request, CancellationToken cancellationToken) {
		var jobMapper = mapper.Map<JobModel>(request.model);
		var updatedJob = await jobRepository.UpdateJobAsync(jobMapper);
		if(updatedJob != null) {
			return updatedJob;
		}
		else {
			throw new Exception("Update job failed");
		}	
	}
}
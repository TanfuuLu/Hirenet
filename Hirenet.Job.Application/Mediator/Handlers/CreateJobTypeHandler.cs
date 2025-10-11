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
public class CreateJobTypeHandler : IRequestHandler<CreateJobTypeCommand, JobType> {
	private readonly IJobTypeRepository jobTypeRepository;
	private readonly IMapper mapper;

    public CreateJobTypeHandler(IJobTypeRepository jobTypeRepository, IMapper mapper) {
	  this.jobTypeRepository = jobTypeRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<JobType> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken) {
		var mappedItem = mapper.Map<JobType>(request.item);
		var result = await jobTypeRepository.CreateJobType(mappedItem);
		return result;

    }
}

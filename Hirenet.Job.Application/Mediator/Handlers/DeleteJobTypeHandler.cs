using Hirenet.Job.Application.Interfaces;
using Hirenet.Job.Application.Mediator.Commands;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Handlers;
public class DeleteJobTypeHandler : IRequestHandler<DeleteJobTypeCommand, bool> {
	private readonly IJobTypeRepository jobTypeRepository;
	private readonly IMapper  mapper;

    public DeleteJobTypeHandler(IJobTypeRepository jobTypeRepository, IMapper mapper) {
	  this.jobTypeRepository = jobTypeRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<bool> Handle(DeleteJobTypeCommand request, CancellationToken cancellationToken) {
		var result = await jobTypeRepository.DeleteJobType(request.jobTypeId);
		return result;
    }
}
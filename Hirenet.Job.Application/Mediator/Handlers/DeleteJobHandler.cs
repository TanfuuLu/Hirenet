using Hirenet.Job.Application.Interfaces;
using Hirenet.Job.Application.Mediator.Commands;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Handlers;
public class DeleteJobHandler : IRequestHandler<DeleteJobCommand, bool> {
	private readonly IJobRepository jobRepository;

    public DeleteJobHandler(IJobRepository jobRepository) {
	  this.jobRepository = jobRepository;
    }

    public async ValueTask<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken) {
	  var result = await jobRepository.DeleteJobAsync(request.jobId);
		return result;
	}
}

using Hirenet.Contract.Application.Cqrs.Milestones.Commands;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Milestones.Handlers;
public class UploadMilestoneFileHandler : IRequestHandler<UploadMilestoneFileCommand, MilestoneFile> {
	private readonly IMilestoneFileRepository repository;

    public UploadMilestoneFileHandler(IMilestoneFileRepository repository) {
	  this.repository = repository;
    }

    public async ValueTask<MilestoneFile> Handle(UploadMilestoneFileCommand request, CancellationToken cancellationToken) {
		var result = await repository.UploadFileAsync(request.modelDto, request.modelDto.rootPath);
		return result;	
    }
}

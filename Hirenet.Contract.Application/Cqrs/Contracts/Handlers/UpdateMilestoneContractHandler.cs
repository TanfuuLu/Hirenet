using Hirenet.Contract.Application.Cqrs.Contracts.Commands;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Contracts.Handlers;
public class UpdateMilestoneContractHandler : IRequestHandler<UpdateMilestoneContractCommand, JobContract> {
	private readonly IContractRepository contractRepository;

	public UpdateMilestoneContractHandler(IContractRepository contractRepository) {
		this.contractRepository = contractRepository;
	}

	public async ValueTask<JobContract> Handle(UpdateMilestoneContractCommand request, CancellationToken cancellationToken) {
		var result = await contractRepository.UpdateMilestonesContractAsync(request.model.MilestonesId, request.model.ContractId);
		return result;
	}
}

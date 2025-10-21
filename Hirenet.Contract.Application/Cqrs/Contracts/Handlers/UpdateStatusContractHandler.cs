using Hirenet.Contract.Application.Cqrs.Contracts.Commands;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Contracts.Handlers;
public class UpdateStatusContractHandler : IRequestHandler<UpdateStatusContractCommand, JobContract> {
	private readonly IContractRepository contractRepository;
	private readonly IMapper mapper;

	public UpdateStatusContractHandler(IContractRepository contractRepository, IMapper mapper) {
		this.contractRepository = contractRepository;
		this.mapper = mapper;
	}

	public async ValueTask<JobContract> Handle(UpdateStatusContractCommand request, CancellationToken cancellationToken) {
		var result = await contractRepository.UpdateContractStatusAsync(request.model.ContractStatus, request.model.ContractId);
		return result;
	}
}

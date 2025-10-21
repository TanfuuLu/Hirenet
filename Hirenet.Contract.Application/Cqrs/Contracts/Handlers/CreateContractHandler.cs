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
public class CreateContractHandler : IRequestHandler<CreateContractCommand, JobContract> {
	private readonly IContractRepository contractRepository;
	private readonly IMapper mapper;

	public CreateContractHandler(IContractRepository contractRepository, IMapper mapper) {
		this.contractRepository = contractRepository;
		this.mapper = mapper;
	}

	public async ValueTask<JobContract> Handle(CreateContractCommand request, CancellationToken cancellationToken) {
		var contractDomain = mapper.Map<JobContract>(request.model);
		var createdContract = await contractRepository.CreateContractAsync(contractDomain);
		return createdContract;
	}
}

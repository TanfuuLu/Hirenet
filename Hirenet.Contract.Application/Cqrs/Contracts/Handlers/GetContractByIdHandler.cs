using Hirenet.Contract.Application.Cqrs.Contracts.Queries;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Contracts.Handlers;
public class GetContractByIdHandler : IRequestHandler<GetContractByIdQuery, JobContract> {
	private readonly IContractRepository contractRepository;

    public GetContractByIdHandler(IContractRepository contractRepository) {
	  this.contractRepository = contractRepository;
    }

    public async ValueTask<JobContract> Handle(GetContractByIdQuery request, CancellationToken cancellationToken) {
	  var result = await contractRepository.GetContractByIdAsync(request.contractId);
		return result;

	}
}

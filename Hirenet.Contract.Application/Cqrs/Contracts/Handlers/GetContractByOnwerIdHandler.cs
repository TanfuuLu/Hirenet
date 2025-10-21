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
public class GetContractByOnwerIdHandler : IRequestHandler<GetContractByOnwerIdQuery, ICollection<JobContract>> {
	private readonly IContractRepository contractRepository;

	public GetContractByOnwerIdHandler(IContractRepository contractRepository) {
		this.contractRepository = contractRepository;
	}

	public async ValueTask<ICollection<JobContract>> Handle(GetContractByOnwerIdQuery request, CancellationToken cancellationToken) {
		var result = await contractRepository.GetContractByOwnerIdAsync(request.ownerId);
		return result;


	}
}

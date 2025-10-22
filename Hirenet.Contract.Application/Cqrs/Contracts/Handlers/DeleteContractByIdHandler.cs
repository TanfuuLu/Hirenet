using Hirenet.Contract.Application.Cqrs.Contracts.Commands;
using Hirenet.Contract.Application.Interfaces;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Contracts.Handlers;
public class DeleteContractByIdHandler : IRequestHandler<DeleteContractByIdCommand, bool> {
	private readonly IContractRepository contractRepository;

    public DeleteContractByIdHandler(IContractRepository contractRepository) {
	  this.contractRepository = contractRepository;
    }

    public async ValueTask<bool> Handle(DeleteContractByIdCommand request, CancellationToken cancellationToken) {
		var result = await contractRepository.DeleteContractAsync(request.contractId);
		return result;
	}
}

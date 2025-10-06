using Hirenet.Authenticate.Application.Interfaces;
using Hirenet.Authenticate.Application.Mediator.Commands;
using Hirenet.Authenticate.Domain;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Mediator.Handlers;
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User> {
	private readonly IUserRepository userRepository;

    public UpdateUserHandler(IUserRepository userRepository) {
	  this.userRepository = userRepository;
    }

    public async ValueTask<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
	  var result = await userRepository.UpdateUser(request.model);
		return result;
	}
}

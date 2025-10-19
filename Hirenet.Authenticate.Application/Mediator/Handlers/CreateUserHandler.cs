using Hirenet.Authenticate.Application.Interfaces;
using Hirenet.Authenticate.Application.Mediator.Commands;
using Hirenet.Authenticate.Domain;
using Mapster;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Mediator.Handlers;
public class CreateUserHandler : IRequestHandler<CreateUserCommand, User> {
	private readonly IUserRepository userRepository;
	private readonly IMapper mapper;


    public CreateUserHandler(IUserRepository userRepository, IMapper mapper) {
	  this.userRepository = userRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<User> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
		var itemModel = mapper.Map<User>(request.model);
		var result = await userRepository.CreateUser(itemModel, request.model.Password);
		if(result != null) {
			return result;
		}else {
			throw new Exception("Fail me roi ");
		}
  	}
}

using Hirenet.Authenticate.Application.DTOs;
using Hirenet.Authenticate.Application.Interfaces;
using Hirenet.Authenticate.Application.Mediator.Commands;
using MapsterMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Mediator.Handlers;
public class LoginHandler : IRequestHandler<LoginCommand, LoginReponse> {
	private readonly IUserRepository _userRepository;
	private readonly IMapper mapper;

    public LoginHandler(IUserRepository userRepository, IMapper mapper) {
	  this._userRepository = userRepository;
	  this.mapper = mapper;
    }

    public async ValueTask<LoginReponse> Handle(LoginCommand request, CancellationToken cancellationToken) {
	  var result = await _userRepository.LoginAccount(request.model.Email, request.model.Password, request.model.RememberMe );
		if ( result != null ) {
			var response = mapper.Map<LoginReponse>(result);
			return response;
		}
		else {
			throw new Exception("Login failed");
		}
	}
}

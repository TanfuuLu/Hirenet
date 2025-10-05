using Hirenet.Authenticate.Application.DTOs;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Mediator.Commands;
public record  LoginCommand(LoginUserDTO model) : IRequest<LoginReponse>;

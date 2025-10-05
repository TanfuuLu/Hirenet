using Hirenet.Authenticate.Application.DTOs;
using Hirenet.Authenticate.Domain;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Mediator.Commands;
public record  CreateUserCommand (CreateUserDTO model) : IRequest<User>;

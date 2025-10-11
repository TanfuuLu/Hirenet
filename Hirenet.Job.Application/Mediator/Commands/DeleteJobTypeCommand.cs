using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Commands;
public record DeleteJobTypeCommand(int jobTypeId) : IRequest<bool>;

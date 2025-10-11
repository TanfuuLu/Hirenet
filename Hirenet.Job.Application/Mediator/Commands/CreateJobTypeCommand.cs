using Hirenet.Job.Application.DTOs;
using Hirenet.Job.Domain;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Commands;
public record CreateJobTypeCommand (ModifyJobType item) : IRequest<JobType>;
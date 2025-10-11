using Hirenet.Job.Domain;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Queries;
public record  GetListJobTypeQuery : IRequest<List<JobType>>;

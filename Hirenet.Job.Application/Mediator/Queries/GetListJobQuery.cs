using Hirenet.Job.Domain;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Mediator.Queries;
public record  GetListJobQuery(): IRequest<List<JobModel>>;
public record  GetJobByID(int jobId): IRequest<JobModel>;
public record  GetListJobByFilter(string? companyName, string? jobType): IRequest<List<JobModel>>;

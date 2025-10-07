using Hirenet.Job.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hirenet.Job.Application.Interfaces;
public interface IJobRepository {
	Task<List<JobModel>> GetAllJobsAsync();
	Task<List<JobModel>> GetJobsByFilterAsync(string? companyName, string? jobType);
	Task<JobModel> GetJobByIdAsync(int jobId);
	Task<JobModel> AddJobAsync(JobModel job);
	Task<JobModel> UpdateJobAsync(JobModel job);
	Task<bool> DeleteJobAsync(int jobId);
}

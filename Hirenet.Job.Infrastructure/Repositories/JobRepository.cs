using Hirenet.Job.Application.Interfaces;
using Hirenet.Job.Domain;
using Hirenet.Job.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Infrastructure.Repositories;
public class JobRepository : IJobRepository {
	private readonly JobDbContext context;

	public JobRepository(JobDbContext context) {
		this.context = context;
	}

	public async Task<JobModel> AddJobAsync(JobModel job) {
		if (job.JobName == null || job.JobDetail == null || job.JobRequirement == null || job.CompanyName == null || job.WorkType == null || job.JobType == null || job.SalaryRange == null) {
			throw new ArgumentException("Job fields cannot be null");
		}
		await context.Jobs.AddAsync(job);
		await context.SaveChangesAsync();

		return job;
	}
	public async Task<bool> DeleteJobAsync(int jobId) {
		var jobExisted = await context.Jobs.FindAsync(jobId);
		if (jobExisted == null) {
			return false;
		}
		context.Jobs.Remove(jobExisted);
		await context.SaveChangesAsync();
		return true;
	}

	public async Task<List<JobModel>> GetAllJobsAsync() {
		var jobList = await context.Jobs.ToListAsync();
		return jobList;
	}

	public async Task<JobModel> GetJobByIdAsync(int jobId) {
		var jobExisted = await context.Jobs.FirstOrDefaultAsync(j => j.JobID == jobId);
		if (jobExisted == null) {
			throw new KeyNotFoundException($"Job with ID {jobId} not found.");
		}
		return jobExisted;
	}

	public async Task<List<JobModel>> GetJobsByFilterAsync(string? companyName, string? jobType) {
		dynamic jobList;
		if (companyName != null) {
			jobList = await context.Jobs.Where(j => j.CompanyName == companyName).ToListAsync();
		}
		if( jobType != null) {
			jobList = await context.Jobs.Where(j => j.JobType == jobType).ToListAsync();
		}
		if(jobType != null && companyName != null) {
			jobList = await context.Jobs.Where(j => j.CompanyName == companyName && j.JobType == jobType).ToListAsync();
		}
		else {
			jobList = await context.Jobs.ToListAsync();
		}
		return jobList;
	}

	public async Task<JobModel> UpdateJobAsync(JobModel job) {
		var jobExisted = await context.Jobs.FirstOrDefaultAsync(j => j.JobID == job.JobID);
		if (jobExisted == null) {
			throw new KeyNotFoundException($"Job with ID {job.JobID} not found.");
		}
		jobExisted.JobName = job.JobName ?? jobExisted.JobName;
		jobExisted.JobDetail = job.JobDetail ?? jobExisted.JobDetail;
		jobExisted.JobRequirement = job.JobRequirement ?? jobExisted.JobRequirement;
		jobExisted.SalaryRange = job.SalaryRange ?? jobExisted.SalaryRange;
		jobExisted.JobType = job.JobType ?? jobExisted.JobType;
		jobExisted.ExpiredDate = job.ExpiredDate != default ? job.ExpiredDate : jobExisted.ExpiredDate;
		await context.SaveChangesAsync();
		return jobExisted;
	}
}

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
public class JobTypeRepository : IJobTypeRepository {
	private readonly JobDbContext dbContext;

	public JobTypeRepository(JobDbContext dbContext) {
		this.dbContext = dbContext;
	}

	public async Task<JobType> CreateJobType(JobType item) {
		await dbContext.JobTypes.AddAsync(item);
		await dbContext.SaveChangesAsync();
		return item;
	}

	public async Task<bool> DeleteJobType(int item) {
		var checkExisted = await dbContext.JobTypes.FirstOrDefaultAsync(j => j.JobTypeId == item);
		if (checkExisted != null) {
			dbContext.JobTypes.Remove(checkExisted);
			await dbContext.SaveChangesAsync();
			return true;
		}
		return false;
	}

	public async Task<List<JobType>> GetAllJobTypes() {
		var listJobType = await dbContext.JobTypes.ToListAsync();
		return listJobType;
	}
}

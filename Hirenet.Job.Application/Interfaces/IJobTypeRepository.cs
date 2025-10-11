using Hirenet.Job.Application.DTOs;
using Hirenet.Job.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.Interfaces;
public interface IJobTypeRepository {
	Task<JobType> CreateJobType(JobType item);
	Task<bool> DeleteJobType(int item);
	Task<List<JobType>> GetAllJobTypes();
}

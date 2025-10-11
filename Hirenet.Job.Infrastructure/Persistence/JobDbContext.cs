using Hirenet.Job.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Infrastructure.Persistence;
public class JobDbContext : DbContext{
	public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }
	public DbSet<JobModel> Jobs { get; set; }
	public DbSet<JobType> JobTypes { get; set; }
}

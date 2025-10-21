using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hirenet.Contract.Domain.Models;
namespace Hirenet.Contract.Infrastructure.Persistence;
public class ContractDbContext : DbContext {
    public ContractDbContext(DbContextOptions<ContractDbContext> options) : base(options) {
    }
	
	public DbSet<JobContract> Contracts { get; set; }
	public DbSet<Milestone> Milestones { get; set; }
	public DbSet<MilestoneFile> MilestoneFiles { get; set; }
}

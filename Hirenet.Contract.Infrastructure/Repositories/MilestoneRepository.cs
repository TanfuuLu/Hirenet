using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Enums;
using Hirenet.Contract.Domain.Models;
using Hirenet.Contract.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Infrastructure.Repositories;
public class MilestoneRepository : IMilestoneRepository {
	private readonly ContractDbContext dbContext;

	public MilestoneRepository(ContractDbContext dbContext) {
		this.dbContext = dbContext;
	}

	public async Task<Milestone> CreateMilestoneAsync(Milestone milestone) {
		if (milestone == null) {
			throw new ArgumentNullException(nameof(milestone) + "null value");
		}
		dbContext.Milestones.Add(milestone);
		await dbContext.SaveChangesAsync();
		return milestone;
	}


	public async Task<bool> DeleteMilestoneAsync(int milestoneId) {
		var checkMilestone = await dbContext.Milestones.FindAsync(milestoneId);
		if (checkMilestone == null) {
			return false;
		}
		dbContext.Milestones.Remove(checkMilestone);
		await dbContext.SaveChangesAsync();
		return true;
	}

	public async Task<ICollection<Milestone>> GetAllMilestonesAsync() {
		var mileStonesList = await dbContext.Milestones.ToListAsync();
		return mileStonesList;
	}

    public async Task<ICollection<Milestone>> GetMilestonesByContractIdAsync(int contractId) {
	  var checkMilestonesList = await dbContext.Milestones.Where(m => m.ContractId == contractId).ToListAsync();
	  return checkMilestonesList;
	}

    public async Task<Milestone> UpdateMilestoneAsync(Milestone milestone, int milestoneId) {
		var mileStoneExisted = await dbContext.Milestones.FirstOrDefaultAsync(m => m.MilestoneId == milestoneId);
		if (mileStoneExisted == null) {
			throw new ArgumentException("Milestone not found with the provided ID.");
		}
		mileStoneExisted.MilestoneTitle = milestone.MilestoneTitle;
		mileStoneExisted.MilestoneDescription = milestone.MilestoneDescription;
		mileStoneExisted.MilestoneFiles = milestone.MilestoneFiles;
		mileStoneExisted.MilestoneEndTime = milestone.MilestoneEndTime;
		await dbContext.SaveChangesAsync();
		return mileStoneExisted;

	}

	public async Task<Milestone> UpdateMilestoneStatusAsync(int milestoneId, MilestoneStatus status) {
		var checkExisted = await dbContext.Milestones.FirstOrDefaultAsync(m => m.MilestoneId == milestoneId);
		if (checkExisted == null) {
			throw new Exception("Milestone not found with the provided ID.");

		}
		checkExisted.MilestoneStatus = status;
		await dbContext.SaveChangesAsync();
		return checkExisted;
	}
}

using Hirenet.Contract.Domain.Enums;
using Hirenet.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Interfaces;
public interface IMilestoneRepository {
	Task<ICollection<Milestone>> GetMilestonesByContractIdAsync(int contractId);
	Task<Milestone> GetMilestonesByIdAsync(int milestoneId);
	Task<ICollection<Milestone>> GetAllMilestonesAsync();
	Task<Milestone> CreateMilestoneAsync(Milestone milestone);
	Task<Milestone> UpdateMilestoneAsync(Milestone milestone, int milestoneId);
	Task<Milestone> UpdateMilestoneStatusAsync(int milestoneId, MilestoneStatus status);
	Task<bool> DeleteMilestoneAsync(int milestoneId);


}

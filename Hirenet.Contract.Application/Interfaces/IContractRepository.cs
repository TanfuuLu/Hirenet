using Hirenet.Contract.Domain.Enums;
using Hirenet.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Interfaces;
public interface IContractRepository {
	Task<JobContract> GetContractByIdAsync(int contractId);
	Task<ICollection<JobContract>> GetContractByOwnerIdAsync(string ownerId);	
	Task<JobContract> CreateContractAsync(JobContract contract);
	Task<JobContract> UpdateContractStatusAsync(ContractStatus contract, int contractId);
	Task<JobContract> UpdateMilestonesContractAsync(ICollection<int> milestoneIds, int contractId);
	Task<bool> DeleteContractAsync(int contractId);

}

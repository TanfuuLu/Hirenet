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
public class ContractRepository : IContractRepository {
	private readonly ContractDbContext dbContext;

	public ContractRepository(ContractDbContext dbContext) {
		this.dbContext = dbContext;
	}

	public async Task<JobContract> CreateContractAsync(JobContract contract) {
		if (contract.ClientId == null || contract.OwnerId == null || contract.PaymentType == null) {
			throw new ArgumentNullException(nameof(contract) + "null value");
		}
		dbContext.Contracts.Add(contract);
		await dbContext.SaveChangesAsync();
		return contract;
	}
	public async Task<bool> DeleteContractAsync(int contractId) {
		var checkExisted = await dbContext.Contracts.FindAsync(contractId);
		if (checkExisted != null) {
			return false;
		}
		return true;
	}

	public async Task<ICollection<JobContract>> GetContractByOwnerIdAsync(string ownerId) {
	  var contracts = await dbContext.Contracts.Where(c => c.OwnerId == ownerId).ToListAsync();
		return contracts;

	}

	public async Task<JobContract> GetContractByIdAsync(int contractId) {
		var existed = await dbContext.Contracts.FindAsync(contractId);
		return existed;
	}

	public async Task<JobContract> UpdateContractStatusAsync(ContractStatus contract, int contractId) {
		var existed = await dbContext.Contracts.FirstOrDefaultAsync(c => c.ContractId == contractId);
		if (existed == null) {
			throw new ArgumentException("Not found contract with id: " + contractId);
		}
		existed.ContractStatus = contract;
		await dbContext.SaveChangesAsync();
		return existed;

	}

}

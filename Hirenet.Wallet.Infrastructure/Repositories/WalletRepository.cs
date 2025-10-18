using Hirenet.Wallet.Application.Interfaces;
using Hirenet.Wallet.Domain.Models;
using Hirenet.Wallet.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Infrastructure.Repositories;
public class WalletRepository : IWalletRepository {
	private readonly UserWalletDbContext dbContext;

    public WalletRepository(UserWalletDbContext dbContext) {
	  this.dbContext = dbContext;
    }

    public async Task<UserWallet> CreateUserWallet(UserWallet wallet) {
	  var checkWallet = await dbContext.UserWallet.FirstOrDefaultAsync(w => w.UserId ==  wallet.UserId);
		if (checkWallet != null) {
			throw new Exception("Wallet existed ");
		}
		else {
			dbContext.UserWallet.Add(wallet);
			await dbContext.SaveChangesAsync();
		}
		return wallet;
    }

    public async Task<bool> DeleteUserWallet(string userId) {
	  var checkWallet = await dbContext.UserWallet.FirstOrDefaultAsync( w => w.UserId == userId);
		if(checkWallet != null) {
			dbContext.UserWallet.Remove(checkWallet);
			await dbContext.SaveChangesAsync();
			return true;
		}
		else {
			return false;
		}
    }

    public async Task<UserWallet> GetWalletInformation(string userId) {
	  var checkWallet = await dbContext.UserWallet.FirstOrDefaultAsync(w => w.UserId == userId);
		if (checkWallet != null) {
			return checkWallet;
		}
		else {
			throw new Exception("Not found Wallet of this User");
		}
    }

    public async Task<UserWallet> UpdateUserWallet(decimal newBalance, decimal newEscowBalance, string userId) {
		var checkWallet = await dbContext.UserWallet.FirstOrDefaultAsync(w => w.UserId == userId);
		if (checkWallet != null) {
			checkWallet.AvailableBalance += newBalance;
			checkWallet.EscrowBalance += newEscowBalance;
			await dbContext.SaveChangesAsync();
			return checkWallet;
		}
		else {
			throw new Exception("Not found Wallet");
		}
    }
}

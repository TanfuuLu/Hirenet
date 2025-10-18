using Hirenet.Wallet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Interfaces;
public interface IWalletRepository {
	Task<UserWallet> GetWalletInformation(string userId);
	Task<UserWallet> CreateUserWallet(UserWallet wallet);
	Task<UserWallet> UpdateUserWallet(decimal newBalance, decimal newEscowBalance, string userId);
	Task<bool> DeleteUserWallet(string userId);
}

using Hirenet.Wallet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Infrastructure.Presistence;
public class UserWalletDbContext : DbContext {
    public UserWalletDbContext(DbContextOptions<UserWalletDbContext> options) : base(options) {
    }

    public DbSet<UserWallet> UserWallet {  get; set; }
}

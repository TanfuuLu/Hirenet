using Hirenet.Wallet.Application.Interfaces;
using Hirenet.Wallet.Infrastructure.Presistence;
using Hirenet.Wallet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Infrastructure;
public static class DependencyInjection {
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
		services.AddDbContext<UserWalletDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("WalletDb")));
		services.AddScoped<IWalletRepository, WalletRepository>();
		return services;
	}
	public static void ApplyMigrations(this IServiceProvider services) {
		using var scope = services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<UserWalletDbContext>();
		dbContext.Database.Migrate();
	}
}

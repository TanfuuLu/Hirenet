using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Infrastructure.Persistence;
using Hirenet.Contract.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Infrastructure;
public static class DependencyInjection {
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) {
		services.AddDbContext<ContractDbContext>(options => options.UseSqlServer(config.GetConnectionString("ContractDb")));
		services.AddScoped<IMilestoneFileRepository, MilestoneFileRepository>();
		return services;
	}
	public static void ApplyMigrations(this IServiceProvider services) {
		using var scope = services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<ContractDbContext>();
		dbContext.Database.Migrate();
	}
}

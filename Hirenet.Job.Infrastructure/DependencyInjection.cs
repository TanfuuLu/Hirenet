using Hirenet.Job.Application.Interfaces;
using Hirenet.Job.Infrastructure.Persistence;
using Hirenet.Job.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Infrastructure;
public static class DependencyInjection {
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration builder) {
		
		services.AddScoped<IJobRepository, JobRepository>();
		services.AddScoped<IJobTypeRepository, JobTypeRepository>();

		return services;
	}
	public static void ApplyMigrations(this IServiceProvider services) {
		using var scope = services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<JobDbContext>();
		dbContext.Database.Migrate();
	}
}

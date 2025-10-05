using Hirenet.Authenticate.Application.Interfaces;
using Hirenet.Authenticate.Domain;
using Hirenet.Authenticate.Infrastructure.Persistence;
using Hirenet.Authenticate.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Infrastructure;
public static class DependencyInjection {
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddDbContext<AuthenticateDbContext>(options =>
			options.UseSqlServer(
				configuration.GetConnectionString("AuthenDb")));
		services.AddIdentity<User, IdentityRole>(options => {
			options.Password.RequireDigit = false;
			options.Password.RequireLowercase = false;
			options.Password.RequireUppercase = false;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequiredLength = 6;
			options.User.RequireUniqueEmail = false;
		}).AddEntityFrameworkStores<AuthenticateDbContext>()
		.AddDefaultTokenProviders();
		var jwtSettings = configuration.GetSection("JwtSettings");
		services.AddAuthentication(options => {
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

		}).AddJwtBearer(options => {
			options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = jwtSettings["Issuer"],
				ValidAudience = jwtSettings["Audience"],
				IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
			};
		});

		return services;
	}
	public static void ApplyMigrations(this IServiceProvider services) {
		using var scope = services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<AuthenticateDbContext>();
		dbContext.Database.Migrate();
	}
}

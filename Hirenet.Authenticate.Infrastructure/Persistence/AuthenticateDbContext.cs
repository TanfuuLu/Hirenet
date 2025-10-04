using Hirenet.Authenticate.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Infrastructure.Persistence;
public class AuthenticateDbContext : IdentityDbContext<User> {
	public AuthenticateDbContext(DbContextOptions<AuthenticateDbContext> options) : base(options) { }
	protected override void OnModelCreating(ModelBuilder builder) {
		base.OnModelCreating(builder);

		// Seed initial data
		var adminRoles = new IdentityRole {
			Id = "1",
			Name = "Admin",
			NormalizedName = "ADMIN"
		};
		var userRoles = new IdentityRole {
			Id = "2",
			Name = "User",
			NormalizedName = "USER"
			
		};
		builder.Entity<IdentityRole>().HasData(adminRoles, userRoles);
	}
}


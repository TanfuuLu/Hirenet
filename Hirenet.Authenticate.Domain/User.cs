using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Domain;
public class User : IdentityUser {
	public string FullName { get; set; } = string.Empty;
	public string DateOfBirth { get; set; } = string.Empty;
	public string? Bio { get; set; } = string.Empty;
	public string? ProfileImageUrl { get; set; } = string.Empty;
	public string UserRole { get; set; }// Possible values: "User", "Admin", "Moderator, etc.
	public string? PhoneNumber { get; set; }
	public ICollection<string>? UserField { get; set; } // Possible values: "IT", "HR", "Finance", etc.
	public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	public bool? IsActive { get; set; } = false;
	public DateTime? ActiveTime { get; set; }

}

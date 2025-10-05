using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.DTOs;
public class CreateUserDTO {
	public string FullName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; }
	public string DateOfBirth { get; set; } = string.Empty;
	public string PhoneNumber { get; set; }
	public string UserRole { get; set; }// Possible values: "User", "Admin", "Moderator, etc.
	public ICollection<string>? UserField { get; set; } // Possible values: "IT", "HR", "Finance", etc.
}

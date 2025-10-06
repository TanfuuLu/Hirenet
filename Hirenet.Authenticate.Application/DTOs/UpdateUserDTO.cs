using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.DTOs;
public class UpdateUserDTO {
	public string? Email { get; set; } = string.Empty;
	public string? Bio { get; set; } = string.Empty;
	public string? ProfileImageUrl { get; set; } = string.Empty;
	public ICollection<string>? UserField { get; set; } // Possible values: "IT", "HR", "Finance", etc.
	public bool? IsActive { get; set; } = null;
}

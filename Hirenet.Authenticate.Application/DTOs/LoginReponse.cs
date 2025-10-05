using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.DTOs;
public class LoginReponse {
	public string Token { get; set; }
	public string Email { get; set; }
}

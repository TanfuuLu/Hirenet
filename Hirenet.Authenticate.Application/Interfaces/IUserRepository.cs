using Hirenet.Authenticate.Application.DTOs;
using Hirenet.Authenticate.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Interfaces;
public interface IUserRepository {
	Task<User> CreateUser(User user, string password);
	Task<User> GetUserByEmail(string email);
	Task<LoginReponse> LoginAccount(string email, string password, bool? rememberMe);
	Task<User> UpdateUser(UpdateUserDTO user);
	string GenerateJwtToken(User user, ICollection<string> listRoles, bool? rememberMe);
}

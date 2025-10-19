using Hirenet.Authenticate.Application.DTOs;
using Hirenet.Authenticate.Application.Interfaces;
using Hirenet.Authenticate.Application.Kafkas;
using Hirenet.Authenticate.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Infrastructure.Repositories;
public class UserRepository : IUserRepository {
	private readonly UserManager<User> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IConfiguration _configuration;
	private readonly UserEventProducer _userEventProducer;

    public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, UserEventProducer userEventProducer) {
	  this._userManager = userManager;
	  this._roleManager = roleManager;
	  this._configuration = configuration;
	  this._userEventProducer = userEventProducer;
    }

    public async Task<User> CreateUser(User user, string password) {
		if (user.FullName == null) {
			throw new Exception("FullName cannot be null");
		}
		else if (user.Email == null) {
			throw new Exception("Email cannot be null");
		}
		var userName = user.FullName.Replace(" ", "").ToLower();
		var userItem = new User {
			UserName = userName,
			FullName = user.FullName,
			DateOfBirth = user.DateOfBirth,
			Bio = user.Bio,
			ProfileImageUrl = user.ProfileImageUrl,
			UserRole = user.UserRole,
			UserField = user.UserField,
			Email = user.Email,
			CreatedAt = DateTimeOffset.UtcNow,
			UpdatedAt = DateTimeOffset.UtcNow,
			IsActive = false
		};
		var createUser = await _userManager.CreateAsync(userItem, password);
		if (!createUser.Succeeded) {
			var errors = string.Join(", ", createUser.Errors.Select(e => e.Description));
			throw new Exception($"Failed to create user: {errors}");
		}
		//Role modifier 
		if (user.UserRole != "Admin") {
			await _userManager.AddToRoleAsync(userItem, "User");
		}
		else {
			await _userManager.AddToRoleAsync(userItem, "Admin");
		}
		await _userEventProducer.PublishUserCreatedAsync(userItem.Id);
		return user;

	}

	public string GenerateJwtToken(User user, ICollection<string> listRoles, bool? rememberMe) {
		var jwtSettings = _configuration.GetSection("JwtSettings");
		var claims = new List<System.Security.Claims.Claim> {
			new System.Security.Claims.Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.Id),
			new System.Security.Claims.Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
			new System.Security.Claims.Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};
		if (listRoles != null) {
			foreach (var role in listRoles) {
				claims.Add(new System.Security.Claims.Claim("roles", role));
			}
		}
		var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
		var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
		var expiresTime = Convert.ToDouble(jwtSettings["DurationSetting"]);
		if (rememberMe == true) {
			expiresTime = 30.0;
		}
		var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
			issuer: jwtSettings["Issuer"],
			audience: jwtSettings["Audience"],
			claims: claims,
			expires: DateTime.Now.AddDays(expiresTime),
			signingCredentials: creds
			);
		return new JwtSecurityTokenHandler().WriteToken(token);
	}



	public async Task<User> GetUserByEmail(string email) {
		var checkUser = await _userManager.FindByEmailAsync(email);
		return checkUser;
	}

	public async Task<LoginReponse> LoginAccount(string email, string password, bool? rememberMe) {
		var checkUser = await GetUserByEmail(email);
		if (checkUser == null) {
			throw new Exception("User not found");
		}
		var checkUserLogin = await _userManager.CheckPasswordAsync(checkUser, password);
		var listRolesUser = await _userManager.GetRolesAsync(checkUser);
		var jwtToken = GenerateJwtToken(checkUser, listRolesUser, rememberMe);
		var response = new LoginReponse {
			Token = jwtToken,
			Email = checkUser.Email
		};
		if (checkUserLogin == true) {
			return response;
		}
		else {
			throw new Exception("Login Failed");
		}
	}

	public async Task<User> UpdateUser(UpdateUserDTO user) {
		var checkUser = await _userManager.FindByEmailAsync(user.Email);
		if (checkUser == null) {
			throw new Exception("User not found");
		}
		checkUser.Bio = user.Bio ?? checkUser.Bio;
		checkUser.ProfileImageUrl = user.ProfileImageUrl ?? checkUser.ProfileImageUrl;
		checkUser.UserField = user.UserField ?? checkUser.UserField;
		checkUser.UpdatedAt = DateTimeOffset.UtcNow;
		if(user.IsActive == true) {
			checkUser.ActiveTime = DateTime.Now;
			checkUser.IsActive = true;
		}
		await _userManager.UpdateAsync(checkUser);
		return checkUser;
	}
}

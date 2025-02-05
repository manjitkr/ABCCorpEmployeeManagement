using ABCCorp.EmployeeManagement.Application.Contracts.Identity;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using ABCCorp.EmployeeManagement.Application.Models.Identity;
using ABCCorp.EmployeeManagement.Identity.Models;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
           var user=  _userManager.Users.FirstOrDefault(x=>x.UserName == request.UserName);
            //var user= await _userManager.FindByNameAsync(request.UserName);

            //var user1 = await _userManager.FindByIdAsync(request.UserName);
            if (user == null)
            {
                throw new NotFoundException($"User with {request.UserName} not found.", request.UserName);
            }


            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for '{request.UserName}' are not valid");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains("InactiveAppUser"))
            {
                throw new BadRequestException($"User is marked inactive");
            }

            JwtSecurityToken token = await GenerateToken(user);
            return new AuthResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Token= new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims= await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role,q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user= new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true,
                
            };  
                       
           var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var status = "Inactive";
                await _userManager.AddToRoleAsync(user, $"{status}AppUser");
                return new RegistrationResponse
                {
                    UserId = user.UserName,
                    Status = status
                };
            }
            else
            {
                throw new BadRequestException(string.Join(",", result.Errors.Select(q => q.Description)));
            }
        }

        public async Task ActivateUser(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                throw new NotFoundException($"User with {userName} not found", userName);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains("ActiveAppUser"))
            {
                throw new BadRequestException($"User is already in Active status");
            }
            var result = await _userManager.RemoveFromRoleAsync(user, "InactiveAppUser");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "ActiveAppUser");
            }
            else
            {
                throw new BadRequestException(string.Join(",", result.Errors.Select(q => q.Description)));
            }
        }

        public async Task InactivateUser(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                throw new NotFoundException($"User with {userName} not found", userName);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains("InactiveAppUser"))
            {
                throw new BadRequestException($"User is already in Inactive status");
            }
            var result = await _userManager.RemoveFromRoleAsync(user, "ActiveAppUser");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "InactiveAppUser");
            }
            else
            {
                throw new BadRequestException(string.Join(",", result.Errors.Select(q => q.Description)));
            }
        }

        public async Task AssignAdminRole(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                throw new NotFoundException($"User with {userName} not found", userName);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
                        
            if (userRoles.Contains("Admin"))
            {
                throw new BadRequestException($"User {userName} is already in Admin status");
            }

            if (userRoles.Contains("InactiveAppUser"))
            {
                throw new BadRequestException($"User {userName} is inactive");
            }

            if (!userRoles.Contains("ActiveAppUser"))
            {
                throw new BadRequestException($"User {userName} does not have active role");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "ActiveAppUser");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                throw new BadRequestException(string.Join(",", result.Errors.Select(q => q.Description)));
            }
        }
    }
}

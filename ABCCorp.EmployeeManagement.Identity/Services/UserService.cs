using ABCCorp.EmployeeManagement.Application.Contracts.Identity;
using ABCCorp.EmployeeManagement.Application.Models.Identity;
using ABCCorp.EmployeeManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AppUser> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new AppUser 
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
            };
        }

        public async Task<List<AppUser>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("AppUser");
            
            return users.Select(user => new AppUser
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
            }).ToList();

        }
    }
}

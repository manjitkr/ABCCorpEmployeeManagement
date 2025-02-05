using ABCCorp.EmployeeManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task< List<AppUser>> GetUsers();
        Task<AppUser> GetUser(string userId);
    }
}

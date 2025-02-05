using ABCCorp.EmployeeManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task ActivateUser(string userId);
        Task AssignAdminRole(string userName);
        Task InactivateUser(string userId);
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}

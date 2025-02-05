using ABCCorp.EmployeeManagement.Application.Contracts.Identity;
using ABCCorp.EmployeeManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCCorp.EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var authResponse = await _authService.Login(request);
           
            return Ok(authResponse);
        }


        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var registrationResponse = await _authService.Register(request);
            return Ok(registrationResponse);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("activateUser")]
        public async Task<ActionResult> ActivateUser(string userName)
        { 
           await _authService.ActivateUser(userName);
           return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("inactivateUser")]
        public async Task<ActionResult> InactivateUser(string userName)
        {
            await _authService.InactivateUser(userName);
            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("AssignAdminRole")]
        public async Task<ActionResult> AssignAdminRole(string userName)
        {
            await _authService.AssignAdminRole(userName);
            return NoContent();
        }





    }
}

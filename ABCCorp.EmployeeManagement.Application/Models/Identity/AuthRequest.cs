using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Models.Identity
{
    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
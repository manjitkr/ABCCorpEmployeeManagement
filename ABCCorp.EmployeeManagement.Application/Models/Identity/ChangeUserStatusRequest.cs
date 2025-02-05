using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Models.Identity
{
    public class ChangeUserStatusResponse
    {
        public required string UserId { get; set; }
        public required string Status { get; set; }
    }
}

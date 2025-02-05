using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.UpdateEmployeeRecord
{
    public class UpdateEmployeeRecordCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string AdminVerificationStatus { get; set; }
        public string? AdminVerificationComment { get; set; }
    }
}

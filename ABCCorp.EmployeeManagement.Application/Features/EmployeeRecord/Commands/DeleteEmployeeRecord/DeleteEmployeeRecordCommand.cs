using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.DeleteEmployeeRecord
{
    public record DeleteEmployeeRecordCommand(int RecordId):IRequest<Unit>;
   
}

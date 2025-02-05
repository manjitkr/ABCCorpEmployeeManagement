using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.GetEmployeeRecordDetails
{
    public record GetEmployeeRecordDetailsRequest(int Id) : IRequest<EmployeeRecordDetailsDto>;
}

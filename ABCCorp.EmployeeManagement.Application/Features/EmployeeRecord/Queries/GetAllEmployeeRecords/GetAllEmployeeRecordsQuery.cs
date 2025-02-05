using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.GetAllEmployeeRecords
{
    public class GetAllEmployeeRecordsQuery : IRequest<List<EmployeeRecordDetailsDto>>
    {
        public string? FilterFirstName { get; set; }
        public string? FilterLastName { get; set; }
        public string? FilterDateCreated { get; set; }
        public string? FilterDateModified { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

}

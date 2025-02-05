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
    public class GetAllEmployeeRecordsQueryHandler : IRequestHandler<GetAllEmployeeRecordsQuery, List<EmployeeRecordDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public GetAllEmployeeRecordsQueryHandler(IMapper mapper, IEmployeeRecordRepository employeeRecordRepository)
        {
            _mapper = mapper;
            _employeeRecordRepository = employeeRecordRepository;
        }
        public async Task<List<EmployeeRecordDetailsDto>> Handle(GetAllEmployeeRecordsQuery request, CancellationToken cancellationToken)
        {
            var employeeRecords= await _employeeRecordRepository.GetAll( 
                request.FilterFirstName,request.FilterLastName, request.FilterDateCreated,request.FilterDateModified,
                request.SortBy, request.SortDirection,
                request.Page, request.PageSize);

            var data = _mapper.Map<List<EmployeeRecordDetailsDto>>(employeeRecords);

            return data;


        }
    }
}

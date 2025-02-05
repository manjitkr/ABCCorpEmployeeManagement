using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.GetEmployeeRecordDetails
{
    class GetEmployeeRecordDetailsQueryHandler : IRequestHandler<GetEmployeeRecordDetailsRequest, EmployeeRecordDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRecordRepository _employeeRecordRepository;
        public GetEmployeeRecordDetailsQueryHandler(IMapper mapper, IEmployeeRecordRepository employeeRecordRepository)
        {
            _mapper = mapper;
            _employeeRecordRepository = employeeRecordRepository;
        }
        public async Task<EmployeeRecordDetailsDto> Handle(GetEmployeeRecordDetailsRequest request, CancellationToken cancellationToken)
        {
            var employeeRecord = await _employeeRecordRepository.GetByIdAsync(request.Id);
            if (employeeRecord==null)
            {
                throw new NotFoundException(nameof(EmployeeRecord), request.Id);
            }

            var data = _mapper.Map<EmployeeRecordDetailsDto>(employeeRecord);
            return data;
        }
    }
}

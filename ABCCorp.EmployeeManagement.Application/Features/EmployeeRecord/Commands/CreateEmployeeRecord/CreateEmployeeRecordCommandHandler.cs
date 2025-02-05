using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.CreateEmployeeRecord
{
    class CreateEmployeeRecordCommandHandler : IRequestHandler<CreateEmployeeRecordCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public CreateEmployeeRecordCommandHandler(IMapper mapper, IEmployeeRecordRepository employeeRecordRepository)
        {
            _mapper = mapper;
            _employeeRecordRepository = employeeRecordRepository;
        }
        public async Task<int> Handle(CreateEmployeeRecordCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEmployeeRecordCommandValidator(_employeeRecordRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid employee record",validationResult);
            }
            var employeeTypeToCreate = _mapper.Map<ABCCorp.EmployeeManagement.Domain.EmployeeRecord>(request);
            await _employeeRecordRepository.AddAsync(employeeTypeToCreate);
            return employeeTypeToCreate.Id; // Assuming EmployeeRecord has an Id property
        }
    }
}

using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.UpdateEmployeeRecord
{
    class UpdateEmployeeRecordCommandHandler : IRequestHandler<UpdateEmployeeRecordCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public UpdateEmployeeRecordCommandHandler(IMapper mapper, IEmployeeRecordRepository employeeRecordRepository)
        {
            _mapper = mapper;
            _employeeRecordRepository = employeeRecordRepository;
        }
        public async Task<Unit> Handle(UpdateEmployeeRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRecord = await _employeeRecordRepository.GetByIdAsync(request.Id);
                if (existingRecord == null)
                {
                    throw new NotFoundException("Employee Record", request.Id);
                }

                existingRecord.AdminVerificationStatus = request.AdminVerificationStatus;
                existingRecord.AdminVerificationComment = request.AdminVerificationComment;
                
                await _employeeRecordRepository.UpdateAsync(existingRecord);
                return Unit.Value;
            }

            catch (Exception ex)
            {
                throw new Exception($"Handle UpdateEmployeeRecordCommand: {ex.Message}");
            }

            
        }
    }
}

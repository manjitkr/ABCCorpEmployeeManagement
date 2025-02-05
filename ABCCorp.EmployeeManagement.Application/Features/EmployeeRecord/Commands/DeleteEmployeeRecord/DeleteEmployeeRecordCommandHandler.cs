using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.DeleteEmployeeRecord
{
    class DeleteEmployeeRecordCommandHandler : IRequestHandler<DeleteEmployeeRecordCommand, Unit>
    {
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public DeleteEmployeeRecordCommandHandler(IEmployeeRecordRepository employeeRecordRepository)
        {
            _employeeRecordRepository = employeeRecordRepository;
        }
        public async Task<Unit> Handle(DeleteEmployeeRecordCommand request, CancellationToken cancellationToken)
        {
            var employeeRecordToDelete = await _employeeRecordRepository.GetByIdAsync(request.RecordId);

            if (employeeRecordToDelete==null)
            {
                throw new NotFoundException(nameof(EmployeeRecord), request.RecordId);
            }
            await _employeeRecordRepository.DeleteAsync(employeeRecordToDelete);
            return Unit.Value;
        }
    }
}

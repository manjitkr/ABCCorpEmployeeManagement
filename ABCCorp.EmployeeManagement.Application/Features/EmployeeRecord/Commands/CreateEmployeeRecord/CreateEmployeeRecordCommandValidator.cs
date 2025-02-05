using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.CreateEmployeeRecord
{
    public class CreateEmployeeRecordCommandValidator:AbstractValidator<CreateEmployeeRecordCommand>
    {
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public CreateEmployeeRecordCommandValidator(IEmployeeRecordRepository employeeRecordRepository)
        {
            _employeeRecordRepository = employeeRecordRepository;

            RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p)
                .MustAsync(EmployeeEmailIdUnique)
                .WithMessage("Employee email already exists");
          
        }

        private async Task<bool> EmployeeEmailIdUnique(CreateEmployeeRecordCommand command, CancellationToken token)
        {
            var result = await _employeeRecordRepository.IsEmailIdExists(command.Email);
            return !result;
        }
    }
}

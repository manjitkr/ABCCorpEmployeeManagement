using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.UpdateEmployeeRecord
{
    public class UpdateEmployeeRecordCommandValidator : AbstractValidator<UpdateEmployeeRecordCommand>
    {
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public UpdateEmployeeRecordCommandValidator(IEmployeeRecordRepository employeeRecordRepository)
        {

            _employeeRecordRepository = employeeRecordRepository;

            RuleFor(p => p.AdminVerificationStatus)
           .NotEmpty().WithMessage("{AdminVerificationStatus} is required.")
           .Must(status => status == "Approved" || status == "Rejected")
           .WithMessage("Valid values for {AdminVerificationStatus} are 'Approved' and 'Rejected'.");

        }



    }

}
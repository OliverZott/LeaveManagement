using FluentValidation;

namespace LeaveManagement.Application.DTOs.LeaveType.Validators;
internal class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator()); // Includes all rules 

        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} must be present.")
    }
}

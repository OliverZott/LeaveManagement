using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators;
internal class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} must be present.");
    }
}

using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators;
internal class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));

        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} must be present.");
    }
}

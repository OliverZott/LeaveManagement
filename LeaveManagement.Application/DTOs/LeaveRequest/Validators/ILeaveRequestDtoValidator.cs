using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;


        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate)
            .WithMessage("StartDate must be before EndDate.");

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate)
            .WithMessage("{PropertyName} must be after {ComparisonValue}.");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return leaveTypeExists;
            }).WithMessage("{PropertyName} does not exist.");
    }
}
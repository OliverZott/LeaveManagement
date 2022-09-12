using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
internal class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public LeaveTypeDto LeaveTypeDto { get; set; }
}

using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
internal class CreateLeaveRequestCommand : IRequest<int>
{
    public CreateLeaveRequestDto LeaveRequestDto { get; set; }
}

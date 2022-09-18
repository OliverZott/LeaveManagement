using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
internal class DeleteLeaveRequestCommand : IRequest
{
    public int Id { get; set; }
}

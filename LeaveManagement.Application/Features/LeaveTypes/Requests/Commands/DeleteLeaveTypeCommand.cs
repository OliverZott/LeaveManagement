using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
internal class DeleteLeaveTypeCommand : IRequest
{
    public int Id { get; set; }
}

using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
internal class DeleteLeaveAllocationCommand : IRequest
{
    public int Id { get; set; }
}

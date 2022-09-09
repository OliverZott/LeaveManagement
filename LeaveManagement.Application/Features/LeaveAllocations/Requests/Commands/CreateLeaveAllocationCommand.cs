using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
internal class CreateLeaveAllocationCommand : IRequest<int>
{
    public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
}

using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
internal class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}

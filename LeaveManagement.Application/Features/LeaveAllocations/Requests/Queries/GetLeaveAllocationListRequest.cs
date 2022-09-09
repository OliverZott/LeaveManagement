using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
internal class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
{
}

using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
internal class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
{
}

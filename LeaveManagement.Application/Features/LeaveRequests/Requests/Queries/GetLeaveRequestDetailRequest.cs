using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
internal class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}

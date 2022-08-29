using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}

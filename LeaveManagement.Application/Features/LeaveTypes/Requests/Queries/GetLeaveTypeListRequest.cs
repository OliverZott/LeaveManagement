using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
{

}

using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;
internal class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }
    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
        return _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
    }
}

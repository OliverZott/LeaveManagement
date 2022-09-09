using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;
internal class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}

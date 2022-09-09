using AutoMapper;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;
internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        // TODO
        // add mapping profile !!!
        var leaveRequest = _mapper.Map<LeaveRequest>(command.LeaveRequestDto);

        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        return leaveRequest.Id;
    }
}

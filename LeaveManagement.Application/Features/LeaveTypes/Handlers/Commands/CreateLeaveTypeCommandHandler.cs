using AutoMapper;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var leaveType = _mapper.Map<LeaveType>(command.LeaveTypeDto);

        // update after ef core updates
        leaveType = await _leaveTypeRepository.Add(leaveType);

        return leaveType.Id;
    }
}

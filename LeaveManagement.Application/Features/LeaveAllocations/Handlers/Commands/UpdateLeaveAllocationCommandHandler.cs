using AutoMapper;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
internal class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.Get(command.LeaveAllocationDto.Id);
        _mapper.Map(command.LeaveAllocationDto, leaveAllocation);
        await _leaveAllocationRepository.Update(leaveAllocation);
        return Unit.Value;
    }
}

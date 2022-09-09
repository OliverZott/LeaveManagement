using AutoMapper;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
internal class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        var createLeaveAllocation = _mapper.Map<LeaveAllocation>(command.CreateLeaveAllocationDto);

        createLeaveAllocation = await _leaveAllocationRepository.Add(createLeaveAllocation);

        return createLeaveAllocation.Id;
    }
}

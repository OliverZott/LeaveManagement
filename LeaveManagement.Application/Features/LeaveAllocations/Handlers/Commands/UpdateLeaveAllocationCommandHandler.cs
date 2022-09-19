using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
internal class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(command.LeaveAllocationDto);

        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var leaveAllocation = await _leaveAllocationRepository.Get(command.LeaveAllocationDto.Id);
        _mapper.Map(command.LeaveAllocationDto, leaveAllocation);
        await _leaveAllocationRepository.Update(leaveAllocation);
        return Unit.Value;
    }
}

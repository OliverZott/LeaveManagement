using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;
internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(command.LeaveRequestDto);

        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        // TODO
        // add mapping profile !!!
        var leaveRequest = _mapper.Map<LeaveRequest>(command.LeaveRequestDto);

        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        return leaveRequest.Id;
    }
}

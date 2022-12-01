using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveType.Validators;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Application.Responses;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository typeRepository, IMapper mapper)
    {
        _leaveTypeRepository = typeRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveTypeDtoValidator();

        if (command.LeaveTypeDto != null)
        {
            var validationResult = await validator.ValidateAsync(command.LeaveTypeDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(command.LeaveTypeDto);
                // update after ef core updates
                leaveType = await _leaveTypeRepository.Add(leaveType);

                response.Success = true;
                response.Message = "Creation successful";
                response.Id = leaveType.Id;
            }
        }


        return response;
    }
}

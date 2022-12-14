using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Responses;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;

// Alternatively one can define the field of the object in the command, instead of using DTO.
// Here the DTO specifies the object and the request/command only is mechanism for data-transfer
//  - DTO:                  data representation
//  - Request/Handler:      transfer/transportation mechanism
public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveTypeDto? LeaveTypeDto { get; set; }
}

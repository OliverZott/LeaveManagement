using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;

// Alternatively one can define the filed of the object in the command, instead of using DTO.
// Here the DTO specifies the object and the request/command only is mechanism for data-transfer
//  - DTO:                  data representation
//  - Request/Handler:      transfer/transportation mechanism
public class CreateLeaveTypeCommand : IRequest<int>
{
    public LeaveTypeDto? LeaveTypeDto { get; set; }
}

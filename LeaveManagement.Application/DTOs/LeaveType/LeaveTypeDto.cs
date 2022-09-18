using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveType;
public class LeaveTypeDto : BaseDto, ILeaveTypeDto
{
    public string? Name { get; set; }
    public int DefaultDays { get; set; }
}

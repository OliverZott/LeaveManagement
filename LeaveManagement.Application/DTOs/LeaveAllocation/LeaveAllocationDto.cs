using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveAllocation;
public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}

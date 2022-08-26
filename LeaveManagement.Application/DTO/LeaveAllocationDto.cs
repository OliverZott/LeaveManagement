using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;
public class LeaveAllocationDto : BaseDto

{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}

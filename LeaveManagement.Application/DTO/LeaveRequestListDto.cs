using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;
public class LeaveRequestListDto : BaseDto
{
    public LeaveTypeDto LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public bool? Approved { get; set; }
}

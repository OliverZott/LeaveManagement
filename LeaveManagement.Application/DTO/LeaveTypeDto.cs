using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;
public class LeaveTypeDto : BaseDto
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}

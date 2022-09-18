namespace LeaveManagement.Application.DTOs.LeaveRequest;
public class CreateLeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComment { get; set; }
}

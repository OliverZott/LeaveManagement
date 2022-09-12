namespace LeaveManagement.Application.DTOs.LeaveRequest;
internal class CreateLeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string? RequestComment { get; set; }

}

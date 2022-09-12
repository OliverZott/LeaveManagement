using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveRequest;
internal class UpdateLeaveRequestDto : BaseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string? RequestComment { get; set; }
    public bool Cancelled { get; set; }
}

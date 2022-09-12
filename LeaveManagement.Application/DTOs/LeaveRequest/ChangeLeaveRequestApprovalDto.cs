using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveRequest;
internal class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool Approved { get; set; }
}

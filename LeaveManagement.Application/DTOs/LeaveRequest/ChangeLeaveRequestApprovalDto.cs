﻿using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveRequest;
public class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool? Approved { get; set; }
}

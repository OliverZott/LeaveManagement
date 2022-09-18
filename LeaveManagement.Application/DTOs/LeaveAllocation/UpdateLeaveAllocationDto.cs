﻿using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveAllocation;
internal class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}

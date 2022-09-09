﻿using LeaveManagement.Domain.Common;

namespace LeaveManagement.Application.DTOs.LeaveAllocation;
public class CreateLeaveAllocationDto : BaseDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
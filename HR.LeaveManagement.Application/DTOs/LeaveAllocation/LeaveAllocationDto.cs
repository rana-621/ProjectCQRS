﻿using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation;

public class LeaveAllocationDto : BaseDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; } = new();
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}

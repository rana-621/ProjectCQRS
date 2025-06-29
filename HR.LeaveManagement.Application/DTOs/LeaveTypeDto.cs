using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs;

public class LeaveTypeDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string DefaultDays { get; set; } = string.Empty;
}

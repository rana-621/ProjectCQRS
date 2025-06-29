using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; } = string.Empty;
    public string DefaultDays { get; set; } = string.Empty;
}

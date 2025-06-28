﻿namespace HR.LeaveManagement.Domain;

public class LeaveType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DefaultDays { get; set; }
    public DateTime DateCreated { get; set; }
}

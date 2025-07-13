using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email eamil);
}

using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Infrastructure.Mail;

public class EmailSender : IEmailSender
{
    public Task<bool> SendEmail(Email eamil)
    {
        throw new NotImplementedException();
    }
}

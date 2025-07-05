using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestsWithDetails();
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
}

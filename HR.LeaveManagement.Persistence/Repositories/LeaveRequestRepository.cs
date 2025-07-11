using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly HrLeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequest> GetLeaveRequestsWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        throw new NotImplementedException();
    }
}

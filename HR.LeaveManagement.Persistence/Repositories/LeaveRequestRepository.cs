using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly HrLeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        leaveRequest.Approved = ApprovalStatus;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _dbContext.LeaveRequests
              .Include(p => p.LeaveType)
              .ToListAsync();

        return leaveRequests;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _dbContext.LeaveRequests
            .Include(p => p.LeaveType)
            .FirstOrDefaultAsync(p => p.Id == id);
        return leaveRequest;

    }
}

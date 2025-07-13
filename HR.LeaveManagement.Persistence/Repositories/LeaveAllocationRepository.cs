using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly HrLeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = _dbContext.LeaveAllocations
            .Include(p => p.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = _dbContext.LeaveAllocations
            .Include(p => p.LeaveType)
            .FirstOrDefaultAsync(p => p.Id == id);
        return leaveAllocation;
    }
}

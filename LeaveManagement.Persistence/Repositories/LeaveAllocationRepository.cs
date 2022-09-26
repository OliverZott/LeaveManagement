using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories;
public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int requestId)
    {
        var leaveAllocation = await _dbContext.LeaveAllocations
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == requestId);
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _dbContext.LeaveAllocations
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }
}

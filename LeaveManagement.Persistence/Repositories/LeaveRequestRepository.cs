﻿using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories;
public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _dbContext.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequest = await _dbContext.LeaveRequests
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveRequest;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved)
    {
        leaveRequest.Approved = approved;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}

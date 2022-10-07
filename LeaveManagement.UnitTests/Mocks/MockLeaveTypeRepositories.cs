using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using Moq;

namespace LeaveManagement.UnitTests.Mocks;
public static class MockLeaveTypeRepositories
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Vacation"
            },
            new LeaveType
            {
                Id = 2,
                DefaultDays = 12,
                Name = "Sick"
            }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();
        mockRepo.Setup(x => x.GetAll()).ReturnsAsync(leaveTypes);
        mockRepo.Setup(x => x.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return leaveType;
        });

        return mockRepo;
    }
}

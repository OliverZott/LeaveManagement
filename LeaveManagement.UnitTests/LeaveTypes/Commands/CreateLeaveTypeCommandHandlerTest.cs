using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Application.Profiles;
using LeaveManagement.Application.Responses;
using LeaveManagement.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace LeaveManagement.UnitTests.LeaveTypes.Commands;
public class CreateLeaveTypeCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mock;

    public CreateLeaveTypeCommandHandlerTest()
    {
        _mock = MockLeaveTypeRepositories.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Valid_LeaveType_Added()
    {
        // Arrange
        var handler = new CreateLeaveTypeCommandHandler(_mock.Object, _mapper);

        var leaveTypeDto = new CreateLeaveTypeDto
        {
            Name = "Test1",
            DefaultDays = 10
        };
        var createLeaveTypeCommand = new CreateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };

        // Act
        var result = await handler.Handle(createLeaveTypeCommand, CancellationToken.None);
        var leaveTypes = _mock.Object.GetAll();

        // Assert
        result.ShouldBeOfType<BaseCommandResponse>();
        leaveTypes.Result.Count().ShouldBe(3);
    }

    [Fact]
    public async Task Invalid_LeaveType_Added()
    {
        // Arrange
        var handler = new CreateLeaveTypeCommandHandler(_mock.Object, _mapper);
        var invalidLeaveTypeDto = new CreateLeaveTypeDto
        {
            Name = null,
            DefaultDays = -1
        };
        var createLeaveTypeCommand = new CreateLeaveTypeCommand { LeaveTypeDto = invalidLeaveTypeDto };

        var expected = new BaseCommandResponse
        {
            Id = 0,
            Success = false,
            Message = "Creation failed",
            Errors = new List<string> { "Name is required", "'Name' must not be empty.", "Default Days must be greater than 0" }
        };

        // Act
        var result = await handler.Handle(createLeaveTypeCommand, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<BaseCommandResponse>();  // easier
        Assert.Equivalent(expected, result);
    }
}

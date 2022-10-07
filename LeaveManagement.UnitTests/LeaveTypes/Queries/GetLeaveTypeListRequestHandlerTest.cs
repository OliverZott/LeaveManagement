using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Application.Profiles;
using LeaveManagement.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace LeaveManagement.UnitTests.LeaveTypes.Queries;
public class GetLeaveTypeListRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;

    public GetLeaveTypeListRequestHandlerTest()
    {
        _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

        // if no await -->  ..Result. needed
        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(2);
    }
}

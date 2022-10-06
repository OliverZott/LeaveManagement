using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<List<LeaveRequestListDto>> Get()
    {
        var leaveRequestDtos = await _mediator.Send(new GetLeaveRequestListRequest());
        return leaveRequestDtos;
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id:int}")]
    public async Task<LeaveRequestDto> Get(int id)
    {
        var leaveRequestDto = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
        return leaveRequestDto;
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<OkObjectResult> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
    {
        var response = await _mediator.Send(new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequestDto });
        return Ok(response);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
    {
        await _mediator.Send(new UpdateLeaveRequestCommand
        {
            Id = id,
            LeaveRequestDto = updateLeaveRequestDto
        });
        return NoContent();
    }

    // PUT api/<LeaveRequestController>/changeapproval/5
    [HttpPut("´changeapproval/{id:int}")]
    public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto? changeLeaveRequestApprovalDto)
    {
        await _mediator.Send(new UpdateLeaveRequestCommand
        {
            Id = id,
            ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto
        });
        return NoContent();
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
        return NoContent();
    }
}

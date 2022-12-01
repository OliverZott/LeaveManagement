using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveTypesController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        // repository call and mapping is inside handler which is called by mediatr!
        var leaveTypeDtos = await _mediator.Send(new GetLeaveTypeListRequest());
        return Ok(leaveTypeDtos);
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        return await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveTypeDto)
    {
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<LeaveTypesController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] LeaveTypeDto leaveTypeDto)
    {
        await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto });
        return NoContent();
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
        return NoContent();
    }
}

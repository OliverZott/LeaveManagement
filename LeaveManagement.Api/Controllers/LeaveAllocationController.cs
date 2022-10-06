using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<List<LeaveAllocationDto>> Get()
    {
        var leaveAllocationDtos = await _mediator.Send(new GetLeaveAllocationListRequest());
        return leaveAllocationDtos;
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocationDto = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
        return Ok(leaveAllocationDto);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<OkObjectResult> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
    {
        var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = createLeaveAllocationDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id:int}")]
    public async Task<NoContentResult> Put(int id, [FromBody] UpdateLeaveAllocationDto updateLeaveAllocationDto)
    {
        await _mediator.Send(new UpdateLeaveAllocationCommand
        {
            LeaveAllocationDto = updateLeaveAllocationDto
        });
        return NoContent();
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id:int}")]
    public async Task<NoContentResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
        return NoContent();
    }
}

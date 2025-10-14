using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

//[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<LeaveTypeDto>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeDetailRequest());
        return Ok(leaveTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
        return Ok(leaveType);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
        var request = await _mediator.Send(command);
        return Ok(request);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CreateLeaveTypeDto leaveType)
    {
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
        await _mediator.Send(command);
        return NoContent();
    }
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveTypeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

}

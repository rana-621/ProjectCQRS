using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LeaveAllocationDto = HR.LeaveManagement.Application.DTOs.LeaveAllocation.LeaveAllocationDto;

namespace HR.LeaveManagement.API.Controllers;

//[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : Controller
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<LeaveAllocationDto>> Get()
    {
        var leaveAllocations = await _mediator.Send(new GetLeaveAllocationDetailRequest());
        return Ok(leaveAllocations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
        return Ok(leaveAllocation);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
    {
        var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
        var request = await _mediator.Send(command);
        return Ok(request);
    }


    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CreateLeaveAllocationDto leaveAllocation)
    {
        var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
        await _mediator.Send(command);
        return NoContent();
    }
    public IActionResult Index()
    {
        return View();
    }


}

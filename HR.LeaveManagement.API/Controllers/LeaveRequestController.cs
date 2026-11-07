using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<LeaveRequestDto>> Get()
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
        return Ok(leaveRequests);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
        return Ok(leaveRequest);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequest };
        var request = await _mediator.Send(command);
        return Ok(request);
    }


    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = leaveRequest };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("changeapproval")]
    public async Task<ActionResult> ChangeApproval([FromBody] ChangeLeaveRequestApprovalDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDto = leaveRequest };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveRequestCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }


    //public IActionResult Index()
    //{
    //    return View();
    //}
}

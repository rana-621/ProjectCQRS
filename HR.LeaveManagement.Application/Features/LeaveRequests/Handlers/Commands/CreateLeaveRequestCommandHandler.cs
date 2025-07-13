using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler :
    IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {

        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

        if (validationResult.IsValid == false)
        {
            response.Success = true;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        //throw new Exception();

        var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
        await _leaveRequestRepository.Add(leaveRequest);

        response.Id = leaveRequest.Id;
        response.Success = true;
        response.Message = "Creation Successful";

        return response;
    }
}
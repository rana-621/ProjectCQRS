using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{

    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;


        RuleFor(x => x.StartDate)
            .LessThan(p => p.EndDate).WithMessage("{ProperyName} must be before {ComparisonValue}.");

        RuleFor(x => x.EndDate)
            .GreaterThan(p => p.StartDate).WithMessage("{ProperyName} must be after {ComparisonValue}.");



        RuleFor(x => x.LeaveTypeId)
           .MustAsync(async (id, token) =>
           {
               var leaveTypeExists = await _leaveTypeRepository.Exists(id);
               return !leaveTypeExists;
           })
           .WithMessage("{ PropertyName} doesnot exist.");
    }
}

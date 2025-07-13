using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;



        RuleFor(x => x.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be before {ComparisonValue}");

        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, cancellation) => await _leaveTypeRepository.Exists(id))
            .WithMessage("{PropertyName} does not exist.");

        RuleFor(x => x.Period)
            .GreaterThan(0).WithMessage("{PropertyName} must be before {ComparisonValue}.");

    }
}
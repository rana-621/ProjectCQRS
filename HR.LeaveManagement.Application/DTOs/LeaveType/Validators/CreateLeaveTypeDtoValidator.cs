using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(x => x.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
    }
}

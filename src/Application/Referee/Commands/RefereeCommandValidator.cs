using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Referee.Commands;

public class RefereecommandValidator : AbstractValidator<CreateRefereeRequest>
{
    public RefereecommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.ApplicantModel)
            .NotEmpty().WithMessage("Applicant is required.");
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required")
            .MaximumLength(200).WithMessage("Email must not exceed 100 characters.");
        RuleFor(v => v.Institution)
            .NotEmpty().WithMessage("Referee institution is required.");
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Referee Name is required.");
        RuleFor(v => v.Position)
            .NotEmpty().WithMessage("Position of referee is required.");
    }
}

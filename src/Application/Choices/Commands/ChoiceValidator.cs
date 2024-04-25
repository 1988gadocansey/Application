using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Referee.Commands;

namespace ApplicantPortal.Application.Choices.Commands;

public class ChoiceValidator: AbstractValidator<ChoiceRequest>
{
    public ChoiceValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.FirstChoice)
            .NotEmpty().WithMessage("First choice is required.");
        RuleFor(v => v.SecondChoice)
            .NotEmpty().WithMessage("second choice is required.");
        RuleFor(v => v.ThirdChoice)
            .NotEmpty().WithMessage("Third Choice is required.");
     
    }
}
 

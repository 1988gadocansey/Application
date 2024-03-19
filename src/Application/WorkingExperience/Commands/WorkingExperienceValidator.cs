using ApplicantPortal.Application.WorkingExperience.Commands;
using FluentValidation;
namespace OnlineApplicationSystem.Application.WorkingExperience.Commands;

public class WorkingExperienceValidator : AbstractValidator<WorkingExperienceRequest>
{

    public WorkingExperienceValidator()
    {
        RuleFor(v => v.CompanyAddress)
           .NotEmpty().WithMessage("Address of company is required.");
        RuleFor(v => v.CompanyPosition)
          .NotEmpty().WithMessage("Position held is required.");
        RuleFor(v => v.CompanyName)
           .NotEmpty().WithMessage("Name of company is required.");
        RuleFor(v => v.CompanyFrom)
            .NotEmpty().WithMessage("Date joined company is required.");


    }
}
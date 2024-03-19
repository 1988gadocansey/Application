using OnlineApplicationSystem.Application.ResearchExperience.Commands;

namespace ApplicantPortal.Application.ResearchExperience.Commands;
public class ResearchExperienceCommandValidator : AbstractValidator<ResearchExperienceRequest>
{

    // private readonly IApplicationDbContext _context;
    public ResearchExperienceCommandValidator()
    {
        //  _context = context;

        RuleFor(v => v.ActualAreaOfResearch)
            .NotEmpty().WithMessage("Actual area of research is required.");
        RuleFor(v => v.AreaOfResearchIfAdmitted)
      .NotEmpty().WithMessage("Area of research if admitted");
        RuleFor(v => v.FutureResearchInterest)
       .NotEmpty().WithMessage("Future research is required.");
        RuleFor(v => v.Month)
        .NotEmpty().WithMessage("Month is required.");
        RuleFor(v => v.Title)
        .NotEmpty().WithMessage("Tile is required.");

    }


}

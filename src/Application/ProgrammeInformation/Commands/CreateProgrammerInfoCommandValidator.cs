using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.ProgrammeInformation.Commands;

public class CreateProgrammerInfoCommandValidator : AbstractValidator<ProgrammeInfoRequest>
{
    private readonly IApplicationDbContext _context;

    public CreateProgrammerInfoCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        /* 
                RuleFor(v => v.Awaiting)
                    .NotEmpty().WithMessage("Awaiting response is required.");

                RuleFor(v => v.EntryMode)
               .NotEmpty().WithMessage("Entry mode is required.");

                RuleFor(v => v.FirstChoiceId)
                   .NotEmpty().WithMessage("First choice is required.");


                RuleFor(v => v.SecondChoiceId)
                  .NotEmpty().WithMessage("Second choice is required.");
                RuleFor(v => v.ThirdChoiceId)
                 .NotEmpty().WithMessage("Third choice is required.");
                RuleFor(v => v.LastYearInSchool)
                     .NotEmpty().WithMessage("Year in school is required.");

         */


    }



}

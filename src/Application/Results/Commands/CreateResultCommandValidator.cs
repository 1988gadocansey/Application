using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Results.Commands;

public class CreateResultCommandValidator : AbstractValidator<CreateResultRequest>
{
    private readonly IApplicationDbContext _context;

    public CreateResultCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.GradeId)
            .NotEmpty().WithMessage("Grade is required.");
        RuleFor(v => v.SubjectId)
            .NotEmpty().WithMessage("Subject is required.")
            ;

        RuleFor(v => v.ExamType)
            .NotEmpty().WithMessage("Exam type is required.");

        RuleFor(v => v.Center)
            .NotEmpty().WithMessage("Center is required.");

        RuleFor(v => v.Year)
            .NotEmpty().WithMessage("Year is required.");

        RuleFor(v => v.Sitting)
            .NotEmpty().WithMessage("Sitting is required.");

        RuleFor(v => v.Month)
            .NotEmpty().WithMessage("Month is required.");

        RuleFor(v => v.IndexNo)
            .NotEmpty().WithMessage("Index No is required.");
    }
}

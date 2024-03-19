using ApplicantPortal.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;

namespace ApplicantPortal.Application.PreviousSHSAttended.Commands;
public class SHSAttendedCommandValidator(IApplicationDbContext context) : AbstractValidator<SHSAttendedRequest>
{

    private readonly IApplicationDbContext _context = context;
    /*    _context = context;
           RuleFor(x => x.StartYear).NotEmpty();
           RuleFor(x => x.EndYear).NotEmpty();
           RuleFor(x => x).Must(x => x.EndYear > x.StartYear)
                   .WithMessage("start date must be less than end date"); */
}

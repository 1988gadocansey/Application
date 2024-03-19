using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;

namespace ApplicantPortal.Application.PreviousSHSAttended.Commands;
public class SHSAttendedCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService)
    : IRequestHandler<SHSAttendedRequest, int>
{
    private readonly IApplicantRepository _applicantRepository = applicantRepository;

    public async Task<int> Handle(SHSAttendedRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var formNo = userDetails.FormNo;
        var applicantDetails = await context.ApplicantModels.FirstOrDefaultAsync(A => A.ApplicationUserId == userId, cancellationToken);
        var school = await context.FormerSchoolModels.FirstOrDefaultAsync(s => s.Id == request.NameId, cancellationToken: cancellationToken);
        var region = await context.RegionModels.FirstOrDefaultAsync(a => a.Id == request.Region, cancellationToken: cancellationToken);
        if (userDetails.Category != "Undergraduate" || userDetails.ForeignApplicant == true) return 0;
        var schoolDetails = new SHSAttendedModel
        {
            Name = school,
            // AttendedTTU = request.AttendedTTU,
            Applicant = applicantDetails,
            Location = region,
            StartYear = request.StartYear,
            EndYear = request.EndYear,
            ProgrammeStudied = request.ProgrammeStudied
        };
        await context.ShsAttendedModels.AddAsync(schoolDetails, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return schoolDetails.Id;
    }
}

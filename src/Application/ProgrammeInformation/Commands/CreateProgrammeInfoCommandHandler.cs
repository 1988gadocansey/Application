using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Interfaces;


namespace ApplicantPortal.Application.ProgrammeInformation.Commands;

public class CreateProgrammeInfoCommandHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    IDateTime dateTime,
    IIdentityService identityService,
    IApplicantRepository applicantRepository)
    : IRequestHandler<ProgrammeInfoRequest, int>
{
    private readonly IDateTime _dateTime = dateTime;
    private readonly IApplicantRepository _applicantRepository = applicantRepository;

    public async Task<int> Handle(ProgrammeInfoRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicant = await context.ApplicantModels
          .FindAsync(new object[] { request.Id! }, cancellationToken);

        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), request.Id!);
        }
        applicant.LastYearInSchool = request.LastYearInSchool;
        applicant.EntryMode = request.EntryMode;
        applicant.FirstChoiceId = request.FirstChoiceId;
        applicant.SecondChoiceId = request.SecondChoiceId;
        applicant.ThirdChoiceId = request.ThirdChoiceId;
        applicant.FirstQualification = request.FirstQualification;
        applicant.SecondQualification = request.SecondQualification;
        applicant.Awaiting = request.Awaiting;
        applicant.IndexNo = request.IndexNo;
        // applicant.Grade = request.Grade;
        return await context.SaveChangesAsync(cancellationToken);
        
    }
}

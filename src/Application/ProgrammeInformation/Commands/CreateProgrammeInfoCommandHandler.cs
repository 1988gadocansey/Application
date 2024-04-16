using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
 

namespace ApplicantPortal.Application.ProgrammeInformation.Commands;

public class CreateProgrammeInfoCommandHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    
    IIdentityService identityService,
    IApplicantRepository applicantRepository)
    : IRequestHandler<ProgrammeInfoRequest, int>
{
    
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
        applicant.PreviousIndexNumber = request.PreviousIndexNumber;
        applicant.SourceOfFinance = request.SourceOfFinance!.ToUpper();
        applicant.SponsorShip = request.Sponsorship!;
        applicant.SponsorShipCompany = request.SponsorshipCompany!;
        applicant.SponsorShipCompanyContact = request.SponsorshipCompanyContact!;
        applicant.SponsorShipLocation = request.SponsorshipLocation!;
        // applicant.Grade = request.Grade;
        return await context.SaveChangesAsync(cancellationToken);
        
    }
}

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using OnlineApplicationSystem.Application.ResearchExperience.Commands;

namespace ApplicantPortal.Application.ResearchExperience.Commands;

public class ResearchExperienceCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<ResearchExperienceRequest, int>
{
    public async Task<int> Handle(ResearchExperienceRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);

        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id.ToString()!); ;
        var data = new ResearchExperienceDto
        {
            Applicant = request.Applicant,
            Month = request.Month,
            AreaOfResearchIfAdmitted = request.AreaOfResearchIfAdmitted,
            FutureResearchInterest = request.FutureResearchInterest,
            ActualAreaOfResearch = request.ActualAreaOfResearch,
            Title = request.Title
        };
        var dataMapped = mapper.Map<ResearchModel>(data);
        await context.ResearchModels.AddAsync(dataMapped, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}

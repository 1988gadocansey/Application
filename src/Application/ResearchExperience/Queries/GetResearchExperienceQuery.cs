using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.ResearchExperience.Queries;

public abstract record GetResearchExperienceQuery : IRequest<PaginatedList<ResearchExperienceDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResearchExperienceHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<GetResearchExperienceQuery, PaginatedList<ResearchExperienceDto>>
{
    public async Task<PaginatedList<ResearchExperienceDto>> Handle(GetResearchExperienceQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        var results = await context.ResearchModels.Include(g => g.Applicant)

                     .Where(r => r.Applicant!.Id == applicantDetails.Id).OrderBy(s => s.Month)
                     .ProjectTo<ResearchExperienceDto>(mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}

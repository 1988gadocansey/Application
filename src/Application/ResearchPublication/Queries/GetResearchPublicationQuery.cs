using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.ResearchPublication.Queries;

public abstract record GetResearchPublicationQuery : IRequest<PaginatedList<ResearchPublicationDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResearchPublicationHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<GetResearchPublicationQuery, PaginatedList<ResearchPublicationDto>>
{
    public async Task<PaginatedList<ResearchPublicationDto>> Handle(GetResearchPublicationQuery request,
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        var results = await context.ResearchPublicationModels.Include(g => g.Applicant)
            .Where(r => r.Applicant!.Id == applicantDetails.Id).OrderBy(s => s.Publication)
            .ProjectTo<ResearchPublicationDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }
}

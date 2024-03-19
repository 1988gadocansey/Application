using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.Issues.Queries;

public abstract record GetIssuesQuery : IRequest<PaginatedList<ApplicantIssueDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetIssuesQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<GetIssuesQuery, PaginatedList<ApplicantIssueDto>>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<PaginatedList<ApplicantIssueDto>> Handle(GetIssuesQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;

        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        var results = await context.ApplicantIssueModels.Include(g => g.Applicant)

                     .Where(r => r.Applicant!.Id == applicantDetails.Id)
                     .ProjectTo<ApplicantIssueDto>(mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}

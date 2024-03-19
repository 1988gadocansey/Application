using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.Referee.Queries;

public abstract record GetRefereeQuery : IRequest<PaginatedList<RefereeDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRefereeHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<GetRefereeQuery, PaginatedList<RefereeDto>>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<PaginatedList<RefereeDto>> Handle(GetRefereeQuery request, CancellationToken cancellationToken)
    {
        
        // var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        var results = await context.ResearchModels.Include(g => g.Applicant)

                     .Where(r => r.Applicant!.Id == applicantDetails.Id).OrderBy(s => s.Month)
                     .ProjectTo<RefereeDto>(mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}

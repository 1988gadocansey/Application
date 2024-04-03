using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.UniversityAttended.Queries;

public   record GetUniversityAttendedQuery : IRequest<PaginatedList<UniversityAttendedDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResearchExperienceHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    IMapper mapper)
    : IRequestHandler<GetUniversityAttendedQuery, PaginatedList<UniversityAttendedDto>>
{
    public async Task<PaginatedList<UniversityAttendedDto>> Handle(GetUniversityAttendedQuery request,
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        //var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = context.ApplicantModels.FirstOrDefault(a => a.ApplicationUserId == userId);

        var results = await context.UniversityAttendedModels
            .Where(r => r.Applicant == applicantDetails).OrderBy(s => s.StartYear)
            .ProjectTo<UniversityAttendedDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }
}

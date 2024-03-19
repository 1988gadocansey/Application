using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.WorkingExperience.Queries;
public abstract record GetWorkingExperienceQuery : IRequest<PaginatedList<WorkingExperienceDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetWorkingExperienceHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<GetWorkingExperienceQuery, PaginatedList<WorkingExperienceDto>>
{
    public async Task<PaginatedList<WorkingExperienceDto>> Handle(GetWorkingExperienceQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        var results = await context.WorkingExperienceModels.Include(g => g.ApplicantModel)

                     .Where(r => r.ApplicantModel!.Id == applicantDetails.Id).OrderBy(s => s.CompanyFrom)
                     .ProjectTo<WorkingExperienceDto>(mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}

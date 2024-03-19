using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.DocumentUpload.Queries;

public abstract record GetDocumentUploadQuery : IRequest<PaginatedList<DocumentUploadDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetDocumentUploadQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<GetDocumentUploadQuery, PaginatedList<DocumentUploadDto>>
{
    public async Task<PaginatedList<DocumentUploadDto>> Handle(GetDocumentUploadQuery request,
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);
        var results = await context.DocumentUploadModels.Include(g => g.Applicant)
            .Where(r => r.Applicant!.Id == applicantDetails.Id).OrderBy(s => s.Name)
            .ProjectTo<DocumentUploadDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }
}

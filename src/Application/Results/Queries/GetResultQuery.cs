using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.Results.Queries;

public abstract record GetResultQuery : IRequest<PaginatedList<ResultsDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResultQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IMapper mapper)
    : IRequestHandler<GetResultQuery, PaginatedList<ResultsDto>>
{
    public async Task<PaginatedList<ResultsDto>> Handle(GetResultQuery request, CancellationToken cancellationToken)
    {
        var applicantDetails =
            await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        PaginatedList<ResultsDto> results = await context.ResultUploadModels.Include(g => g.Grade)
            .Include(s => s.Subject)
            .Where(r => r.ApplicantModelId == applicantDetails.Id).OrderBy(s => s.Year).ThenBy(s => s.Subject!.Type)
            .ProjectTo<ResultsDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }
}

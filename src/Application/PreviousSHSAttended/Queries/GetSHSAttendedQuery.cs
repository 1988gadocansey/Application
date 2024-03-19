using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.PreviousSHSAttended.Queries;
public abstract record GetSHSAttendedQuery : IRequest<PaginatedList<SHSAttendedDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResultQueryHandler : IRequestHandler<GetSHSAttendedQuery, PaginatedList<SHSAttendedDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IUser _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public GetResultQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, IUser currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<PaginatedList<SHSAttendedDto>> Handle(GetSHSAttendedQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.Id;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.Id, cancellationToken);

        var results = await _context.ShsAttendedModels.Include(g => g.Applicant)
                     .Include(s => s.Location)
                     .Where(r => r.Applicant!.Id == applicantDetails.Id).OrderBy(s => s.StartYear).ThenBy(s => s.Location)
                     .ProjectTo<SHSAttendedDto>(_mapper.ConfigurationProvider)

                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}

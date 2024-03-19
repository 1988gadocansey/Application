using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Preview;

public record GetSingleUniversityAttendedQuery : IRequest<UniversityAttendedDto>;

public class GetSingleUniversityAttendedQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IMapper mapper,
    IIdentityService identityService)
    : IRequestHandler<GetSingleUniversityAttendedQuery, UniversityAttendedDto>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly IIdentityService _identityService = identityService;

    public async Task<UniversityAttendedDto> Handle(GetSingleUniversityAttendedQuery request, CancellationToken cancellationToken)
    {

        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        return await applicantRepository.GetSingleUniversityAttended(applicantDetails.Id, cancellationToken);

    }

}

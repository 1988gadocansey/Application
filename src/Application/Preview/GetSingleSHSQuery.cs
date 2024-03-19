using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Preview;

public record GetSingleSHSQuery : IRequest<SHSAttendedDto>;

public class GetSingleSHSQueryQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IMapper mapper,
    IIdentityService identityService)
    : IRequestHandler<GetSingleSHSQuery, SHSAttendedDto>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly IIdentityService _identityService = identityService;

    public async Task<SHSAttendedDto> Handle(GetSingleSHSQuery request, CancellationToken cancellationToken)
    {

        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        return await applicantRepository.GetSingleShsAttended(applicantDetails.Id, cancellationToken);

    }

}

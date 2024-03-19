using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems
{
    public abstract record GetProgrammeQuery : IRequest<IEnumerable<ProgrammeDto>>;

    public class GetProgrammeQueryHandler : IRequestHandler<GetProgrammeQuery, IEnumerable<ProgrammeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly IUser _currentUserService;

        private static readonly Dictionary<string, string> FormTypeMapping = new Dictionary<string, string>
        {
            { "DIPLOMA", "DipTECH" },
            { "MTECH", "MTECH" },
            { "BTECH", "DEGREE" },
            { "MATURE", "BTECH" },
            { "TOPUP", "BTECH" },
            { "BRIDGING", "BTECH" },
            { "CERTIFICATE", "CERT" },
            { "HND", "HND" },
            { "ACCELERATED", "BTECH" }
        };

        public GetProgrammeQueryHandler(
            IApplicationDbContext context,
            IApplicantRepository applicantRepository,
            IUser currentUserService,
            IIdentityService identityService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<IEnumerable<ProgrammeDto>> Handle(GetProgrammeQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _identityService.GetApplicationUserDetails(_currentUserService.Id, cancellationToken);
            var formType = FormTypeMapping.FirstOrDefault(x => x.Value == userDetails.Type.ToString()).Key;

            var programmes = await _context.ProgrammeModels
                .OrderBy(programme => programme.Name)
                .Where(programme => programme.Type == formType)
                .Select(programme => new ProgrammeDto
                {
                    Id = programme.Id,
                    Name = programme.Name,
                    Duration = programme.Duration,
                    Type = programme.Type
                })
                .ToListAsync(cancellationToken);

            return programmes;
        }
    }
}

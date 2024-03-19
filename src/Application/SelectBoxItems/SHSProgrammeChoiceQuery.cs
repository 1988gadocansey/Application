using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

public class GetShsProgrammesQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    : IRequestHandler<GetSHSProgrammesQuery, IEnumerable<SHSProgrammesDto>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<SHSProgrammesDto>> Handle(GetSHSProgrammesQuery request, CancellationToken cancellationToken)
    {
return await applicantRepository.ShsProgrammes(cancellationToken);
        
    }

}

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

 
public abstract record GetDistrictQuery : IRequest<IEnumerable<DistrictDto>>;

public class GetDistrictQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    : IRequestHandler<GetDistrictQuery, IEnumerable<DistrictDto>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<DistrictDto>> Handle(GetDistrictQuery request, CancellationToken cancellationToken) { return await applicantRepository.Districts(cancellationToken); }
}

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

 
public record GetDenominationQuery : IRequest<IEnumerable<DenominationDto>>;

public class GetDenominationQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    : IRequestHandler<GetDenominationQuery, IEnumerable<DenominationDto>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<DenominationDto>> Handle(GetDenominationQuery request, CancellationToken cancellationToken)
    {
        var data = await applicantRepository.Denominations(cancellationToken);
        return data;
    }

}

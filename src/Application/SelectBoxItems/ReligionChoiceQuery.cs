using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

 
public abstract record GetReligionQuery : IRequest<IEnumerable<ReligionDto>>;

public class GetReligionQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    : IRequestHandler<GetReligionQuery, IEnumerable<ReligionDto>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<ReligionDto>> Handle(GetReligionQuery request, CancellationToken cancellationToken)
    {
       return await applicantRepository.Religions(cancellationToken);
       
    }

}

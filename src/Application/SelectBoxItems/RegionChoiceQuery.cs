using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

 
public record GetRegionQuery : IRequest<IEnumerable<RegionDto>>;

public class GetRegionQueryHandler(   IApplicantRepository applicantRepository)
    : IRequestHandler<GetRegionQuery, IEnumerable<RegionDto>>
{
 

    public async Task<IEnumerable<RegionDto>> Handle(GetRegionQuery request, CancellationToken cancellationToken)
    {
       return  await applicantRepository.Regions(cancellationToken);
         
    }

}

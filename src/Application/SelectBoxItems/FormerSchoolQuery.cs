using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

 
public   record GetFormerSchoolQuery : IRequest<IEnumerable<FormerSchoolDto>>;

public class GetFormerSchoolQueryHandler( IApplicantRepository applicantRepository)
    : IRequestHandler<GetFormerSchoolQuery, IEnumerable<FormerSchoolDto>>
{
  

    public async Task<IEnumerable<FormerSchoolDto>> Handle(GetFormerSchoolQuery request, CancellationToken cancellationToken)
    {
        var data = await applicantRepository.Schools(cancellationToken);
        return data;
    }

}

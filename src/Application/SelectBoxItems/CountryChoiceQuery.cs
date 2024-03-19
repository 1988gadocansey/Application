using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

public abstract record GetCountryQuery : IRequest<IEnumerable<CountryDto>>;

public class GetCountryQueryHandler(IApplicantRepository applicantRepository)
    : IRequestHandler<GetCountryQuery, IEnumerable<CountryDto>>
{
    
    public async Task<IEnumerable<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken) { return await applicantRepository.Countries(cancellationToken); }

}

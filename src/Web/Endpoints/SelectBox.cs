using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.PreviousSHSAttended.Queries;
using ApplicantPortal.Application.ResearchPublication.Commands;
using ApplicantPortal.Application.Results.Commands;
using ApplicantPortal.Application.Results.Queries;
using ApplicantPortal.Application.SelectBoxItems;

namespace ApplicantPortal.Web.Endpoints;

public class SelectBox: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetRegions, "Regions")
            .MapGet(GetCountries, "Countries")
            .MapGet(GetSHSAttended, "SHSAttended")
            .MapGet(GetSchools, "Schools")
            .MapGet(GetDenominations, "Denominations")
            .MapGet(GetReligion, "GetReligion")
             ;
    }
    
     
    public async Task<IEnumerable<RegionDto>> GetRegions(ISender sender) => await sender.Send(new GetRegionQuery());
    public async Task<IEnumerable<CountryDto>> GetCountries(ISender sender) => await sender.Send(new GetCountryQuery());
    public async Task<PaginatedList<SHSAttendedDto>> GetSHSAttended(ISender sender) => await sender.Send(new GetSHSAttendedQuery());
    public async Task<IEnumerable<FormerSchoolDto>> GetSchools(ISender sender) => await sender.Send(new GetFormerSchoolQuery());
    public async Task<IEnumerable<DenominationDto>> GetDenominations(ISender sender) => await sender.Send(new GetDenominationQuery());
    public async Task<IEnumerable<ReligionDto>> GetReligion(ISender sender) => await sender.Send(new GetReligionQuery());
   
}

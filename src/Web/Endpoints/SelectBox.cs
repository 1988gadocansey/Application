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
            .MapGet(GetProgrammes, "GetProgrammes")
            .MapGet(GetSHSProgrammes, "GetSHSProgrammes")
            .MapGet(GetSubjects, "GetSubjects")
            .MapGet(GetLanguage, "GetLanguage")
            .MapGet(GetGrades, "GetGrades")
            .MapGet(GetExams, "GetExams")
            .MapGet(GetDistricts, "GetDistricts")
            .MapGet(GetDisabilities, "GetDisabilities")
             ;
    }
    
     
    public async Task<IEnumerable<RegionDto>> GetRegions(ISender sender) => await sender.Send(new GetRegionQuery());
    public async Task<IEnumerable<CountryDto>> GetCountries(ISender sender) => await sender.Send(new GetCountryQuery());
    public async Task<PaginatedList<SHSAttendedDto>> GetSHSAttended(ISender sender) => await sender.Send(new GetSHSAttendedQuery());
    public async Task<IEnumerable<FormerSchoolDto>> GetSchools(ISender sender) => await sender.Send(new GetFormerSchoolQuery());
    public async Task<IEnumerable<DenominationDto>> GetDenominations(ISender sender) => await sender.Send(new GetDenominationQuery());
    public async Task<IEnumerable<ReligionDto>> GetReligion(ISender sender) => await sender.Send(new GetReligionQuery());
    public async Task<IEnumerable<ProgrammeDto>> GetProgrammes(ISender sender) => await sender.Send(new GetProgrammeQuery());
    public async Task<IEnumerable<SHSProgrammesDto>> GetSHSProgrammes(ISender sender) => await sender.Send(new GetSHSProgrammesQuery());
    public async Task<IEnumerable<SubjectDto>> GetSubjects(ISender sender) => await sender.Send(new GetSubjectQuery());
    public async Task<IEnumerable<LanguageDto>> GetLanguage(ISender sender) => await sender.Send(new GetLanguageQuery());
    public async Task<IEnumerable<GradeDto>> GetGrades(ISender sender) => await sender.Send(new GetGradeQuery());
    public async Task<IEnumerable<DistrictDto>> GetDistricts(ISender sender) => await sender.Send(new GetDistrictQuery());
    public async Task<IEnumerable<ExamDto>> GetExams(ISender sender) => await sender.Send(new GetExamQuery());
    public async Task<IEnumerable<string>> GetDisabilities(ISender sender) => await sender.Send(new DisabilityChoiceQuery());

}

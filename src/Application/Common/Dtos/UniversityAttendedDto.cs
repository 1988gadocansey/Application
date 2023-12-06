using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;
namespace ApplicantPortal.Application.Common.Dtos;
public record UniversityAttendedDto : IMapFrom<UniversityAttendedModel>
{

    public int? Id { set; get; }
    public ApplicantModel? Applicant { get; set; }
    public string? Name { set; get; }
    public CountryModel? Location { set; get; }
    public string? StartYear { set; get; }
    public string? EndYear { set; get; }
    public string? StudentNumber { set; get; }
    public string? DegreeObtained { set; get; }
    public string? DegreeClassification { set; get; }
    public decimal? CGPA { set; get; }

    //public string ApplicantModel? Applicant { get; set; }

}

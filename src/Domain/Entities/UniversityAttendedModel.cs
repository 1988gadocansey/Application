using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantPortal.Domain.Entities;

public record UniversityAttendedModel
{
    [Key]
    public int Id { set; get; }
    public string? Name { set; get; }
    public CountryModel? Location { set; get; }
    public string? StartYear { set; get; }
    public string? EndYear { set; get; }
    public string? StudentNumber { set; get; }
    public string? DegreeObtained { set; get; }
    public string? DegreeClassification { set; get; }
    public decimal? CGPA { set; get; }

    public virtual ApplicantModel? Applicant { get; set; }
}

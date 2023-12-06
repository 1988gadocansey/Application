using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record WorkingExperienceDto
{
    public int Id { set; get; }
    public string? CompanyName { set; get; }
    public string? CompanyPhone { set; get; }
    public string? CompanyAddress { set; get; }
    public string? CompanyPosition { set; get; }
    public string? CompanyFrom { set; get; }
    public string? CompanyTo { set; get; }
    public int Applicant { set; get; }

}

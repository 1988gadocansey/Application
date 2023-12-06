using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;



public record DocumentUploadDto
{

    public int Id { get; set; }
    public int Applicant { set; get; }
    public string? Name { set; get; }
    public string? Type { set; get; }

}

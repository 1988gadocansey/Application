using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;
public record ResearchPublicationDto : IMapFrom<ResearchPublicationModel>
{
    public int Id { set; get; }
    public int Applicant { set; get; }
    public string? Publication { get; set; }

}

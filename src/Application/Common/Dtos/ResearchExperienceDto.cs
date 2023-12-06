using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;
namespace ApplicantPortal.Application.Common.Dtos;
public record ResearchExperienceDto : IMapFrom<ResearchModel>
{

    public int Id { set; get; }
    public string? Title { set; get; }
    public string? Month { set; get; }
    public string? AreaOfResearchIfAdmitted { set; get; }
    public string? ActualAreaOfResearch { set; get; }
    public string? FutureResearchInterest { set; get; }
    public int Applicant { set; get; }
}

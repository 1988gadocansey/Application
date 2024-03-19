using MediatR;

namespace OnlineApplicationSystem.Application.ResearchExperience.Commands;
public record ResearchExperienceRequest : IRequest<int>
{

    public int? Id { set; get; }
    public int Applicant { set; get; }
    public string? Title { set; get; }
    public string? Month { set; get; }
    public string? AreaOfResearchIfAdmitted { set; get; }
    public string? ActualAreaOfResearch { set; get; }
    public string? FutureResearchInterest { set; get; }

}
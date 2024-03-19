namespace ApplicantPortal.Application.ResearchPublication.Commands;
public record ResearchPublicationRequest : IRequest<int>
{

    public int Id { set; get; }
    public int Applicant { set; get; }
    public string? Publication { get; set; }

}

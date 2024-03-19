namespace ApplicantPortal.Application.WorkingExperience.Commands;
public record WorkingExperienceRequest : IRequest<int>
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

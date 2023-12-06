namespace ApplicantPortal.Domain.Entities;
public record ApplicantIssueModel : BaseAuditableEntity
{
    public int ApplicantId { set; get; }
    public virtual ApplicantModel? Applicant { set; get; }
    public string? Issue { set; get; }
}

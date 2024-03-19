namespace ApplicantPortal.Domain.Entities;

public record DocumentUploadModel : BaseAuditableEntity
{
    public ApplicantModel? Applicant { set; get; }
    public string? Name { set; get; }
    public string? Type { set; get; }
}

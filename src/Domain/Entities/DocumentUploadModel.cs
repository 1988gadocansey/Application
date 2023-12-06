namespace ApplicantPortal.Domain.Entities;

public record DocumentUploadModel : BaseAuditableEntity
{
    private int Applicant { set; get; }
    private string? Name { set; get; }
    private string? Type { set; get; }
}

namespace ApplicantPortal.Domain.Entities;
using Enums;
public record RefereeModel : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Institution { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public virtual ApplicantModel? ApplicantModel { set; get; }
    public RefereeStatus RefereeStatus { get; set; } = RefereeStatus.Pending;

    
}

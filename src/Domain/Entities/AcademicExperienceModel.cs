using System.ComponentModel.DataAnnotations;
namespace ApplicantPortal.Domain.Entities;

public record AcademicExperienceModel : BaseAuditableEntity
{
    [Key]
    public string? InstitutionName { set; get; }
    public string? InstitutionAddress { set; get; }
    public string? ProgrammeStudied { set; get; }
    public DateTime From { set; get; }
    public DateTime To { set; get; }
    public string? Certificate { set; get; }
    public int ApplicantModelId { set; get; }
    public ApplicantModel? ApplicantModel { get; set; }
}

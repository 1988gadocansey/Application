using System.ComponentModel.DataAnnotations;
namespace ApplicantPortal.Domain.Entities;
public record Choices
{
    [Key]
    public int Id { init; get; }
    public ApplicantModel? Applicant { get; init; }
    public ProgrammeModel? FirstChoice { get; init; }
    public ProgrammeModel? SecondChoice { get; init; }
    public ProgrammeModel? ThirdChoice { get; init; } 
}

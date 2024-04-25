using System.ComponentModel.DataAnnotations;
namespace ApplicantPortal.Domain.Entities;
public record Choices
{
    [Key]
    public int Id { init; get; }
    public ApplicantModel? Applicant { get; set; }
    public ProgrammeModel? FirstChoice { get; set; }
    public ProgrammeModel? SecondChoice { get; set; }
    public ProgrammeModel? ThirdChoice { get; set; } 
}

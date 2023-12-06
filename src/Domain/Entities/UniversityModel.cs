using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities;

public record UniversityModel
{
    [Key] public int Id { set; get; }
    public string? University { set; get; }
    public string? Location { get; set; }
}

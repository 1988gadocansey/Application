
using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities;

public record SHSProgrammes
{
    [Key] public int Id { set; get; }
    public string? Name { get; set; }
}

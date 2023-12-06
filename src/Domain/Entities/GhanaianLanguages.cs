using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities;
public record GhanaianLanguages
{
    [Key]
    public int Id { set; get; }
    public string? Name { set; get; }


}

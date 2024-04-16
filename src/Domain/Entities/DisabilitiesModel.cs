using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities;
public record DisabilitiesModel
{
    [Key]
    public int Id { set; get; }
    public string? Name { set; get; }
    public int? ApplicantModelId { set; get; }

}

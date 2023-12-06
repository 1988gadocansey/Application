using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities;

public class ResearchPublicationModel
{

    [Key]
    public int Id { set; get; }
    public virtual ApplicantModel? Applicant { set; get; }
    public string? Publication { get; set; }

}

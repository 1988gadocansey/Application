using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Application.Common.Dtos;

public record UserDto
{
    public string? Id { get; set; }
      public string? FormNo { get; set; }
    public bool? Started { get; set; }
    public string? FullName { get; set; }
    public string? UserName {get;set;}
    public  ApplicationType Type { get; set; }
    public string? Category { get; set; }
    public bool Sold { get; set; }
    public string? SoldBy { get; set; }
    public string? Branch { get; set; }
    public string? Teller { get; set; }
    public string? TellerPhone { get; set; }
    public bool? FormCompleted { get; set; }
    public bool? PictureUploaded { get; set; }
    public bool? Finalized { get; set; }
    public string? Year { get; set; }
    public bool? ResultUploaded { get; set; }
    public bool Admitted { get; set; }
    public string? Pin { get; set; }
    public bool? ForeignApplicant { get; set; }
    public DateTime? LastLogin { set; get; }
}

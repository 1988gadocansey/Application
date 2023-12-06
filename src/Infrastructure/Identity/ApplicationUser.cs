using ApplicantPortal.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace ApplicantPortal.Infrastructure.Identity;
 
public class ApplicationUser : IdentityUser 
{
    /*public string? FormNo { get; set; }
    public bool? Started { get; set; }
    public string? FullName { get; set; }
    
    public string? Category { get; set; }
    public bool Sold { set; get; }
    public string? SoldBy { set; get; }
    public string? Branch { set; get; }
    public string? Teller { set; get; }
    public string? TellerPhone { set; get; }
    public bool? FormCompleted { set; get; }
    public bool? PictureUploaded { set; get; }
    public bool? Finalized { set; get; }
    public string? Year { get; set; }
    public bool? ResultUploaded { get; set; }
    public bool? Admitted { get; set; }
    public string? Pin { get; set; }
    public bool? ForeignApplicant { get; set;*/
    public string? FormNo { get; set; }
    public bool? Started { get; set; }
    public string? FullName { get; set; }
    public  ApplicationType VoucherType { get; set; }
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

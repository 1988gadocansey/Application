using System.ComponentModel.DataAnnotations;
namespace ApplicantPortal.Domain.Entities;

public record AddressModel
{
    [Key] 
    public int Id { set; get; }
    public string? Street { set; get; }
    public string? HouseNumber { set; get; }
    public string? City { set; get; }
    public string? Gprs { set; get; }
    public string? Box { set; get; }
    public  ApplicantModel? Applicant { get; set; }
}

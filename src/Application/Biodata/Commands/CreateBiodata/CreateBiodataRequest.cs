using MediatR;
using ApplicantPortal.Domain.Enums;
using ApplicantPortal.Domain.ValueObjects;

namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata;

public record CreateBiodataRequest : IRequest<int>
{
    public Guid Id { get; set; }
    public long ApplicationNumber { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? OtherName { get; set; }
    public string? PreviousName { get; init; }
    public int? NoOfChildren { get; init; }
    public Gender Gender { get; init; }
    public DateOnly Dob => DateOnly.Parse(Year + "-" + Month + "-" + Day);
    public string? Month { get; init; }
    public string? Year { get; init; }
    public string? Day { get; init; }
    public Title Title { get; init; }
    public MaritalStatus? MaritalStatus { get; set; } = Domain.Enums.MaritalStatus.Single;
    public string? Phone { get; init; }
    public string? AltPhone { get; set; }
    public string? Email { get; init; }
    public string? PostGprs { get; init; }
    public string? EmergencyContact { get; set; }
    public string? Hometown { get; init; }
    public int? District { get; init; }
   // public string? NationalIdNo { get; set; }
   public string? NationalIdNo { get; set; }
   public IDCards? NationalIdType { get; set; }
    public int? RegionId { get; set; }

    public int? NationalityId { get; init; }
    public bool? ResidentialStatus { get; init; }
    public string? GuardianName { get; init; }
    public string? GuardianPhone { get; init; }
    public string? GuardianOccupation { get; init; }
    public string? GuardianRelationship { get; init; }
    public bool? Disability { get; init; }
    public Disability? DisabilityType { get; init; }
    public string? SourceOfFinance { get; init; }
    public int? ReligionId { get; init; }
    public string? Denomination { get; init; }
     
    public string? Referrals { get; init; }
    public bool? Admitted { get; init; }
    public string? Leveladmitted { get; init; }
    public int? Grade { get; init; }
    public int? AdmittedBy { get; init; }
    public bool? SponsorShip { get; init; }
    public string? SponsorShipCompany { get; init; }
    public string? SponsorShipLocation { get; init; }
    public string? SponsorShipCompanyContact { get; init; }
}

using System;
using ApplicantPortal.Domain.Enums;
using MediatR;

namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata
{
    public record CreateBiodataRequest : IRequest<int>
    {
        public int? Id { get; init; }
        public long ApplicationNumber { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? OtherName { get; init; }
        public string? PreviousName { get; init; }
        public int? NoOfChildren { get; init; }
        public Gender Gender { get; init; }
        public DateOnly DateOfBirth   => DateOnly.Parse(Year + "-" + Month + "-" + Day);
        public string? Month { get; init; }
        public string? Year { get; init; }
        public string? Day { get; init; }
        public Title Title { get; init; }
        public  MaritalStatus? MaritalStatus { get; set; } =  Domain.Enums.MaritalStatus.Single;
        public string? Phone { get; init; }
        public string? AltPhone { get; init; }
        public string? Email { get; init; }
        public string? PostGPRS { get; init; }
        public string? EmergencyContact { get; init; }
        public string? Hometown { get; init; }
        public int? District { get; init; }
        public int? RegionId { get; init; }
        public int? NationalityId { get; init; }
        public bool? ResidentialStatus { get; init; }
        public string? GuardianName { get; init; }
        public string? GuardianPhone { get; init; }
        public string? GuardianOccupation { get; init; }
        public string? GuardianRelationship { get; init; }
        public bool? Disability { get; init; }
        public Disability? DisabilityType { get; init; }
        public string? SourceOfFinance { get; init; }
        public int ReligionId { get; init; }
        public string? Denomination { get; init; }
        public IdCards IdCard { get; init; }
        public string? Referrals { get; init; }
        /*public bool? Admitted { get; init; }
        public string? LevelAdmitted { get; init; }
        public int? Grade { get; init; }
        public int? AdmittedBy { get; init; }*/
        public bool? Sponsorship { get; set; }
        public string? SponsorshipCompany { get; set; }
        public string? SponsorshipLocation { get; set; }
        public string? SponsorshipCompanyContact { get; set; }
        public string? NationalIDNo { get; set; }
       // public string? PreviousIndexNumber { get; set; }
        public Languages[]? Languages { get; set; }
    }
}

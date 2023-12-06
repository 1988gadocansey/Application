using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.Enums;
using ApplicantPortal.Domain.ValueObjects;

namespace ApplicantPortal.Application.Common.Dtos;

public class ApplicantDto : IMapFrom<ApplicantModel>
{
    public int Id { get; set; }

    public ApplicationNumber? ApplicationNumber { get; set; }
    public Title Title { set; get; }
    public ApplicantName? ApplicantName { get; set; }
    public ApplicantName? PreviousName { get; set; }

    public DateOnly Dob { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public MaritalStatus? MaritalStatus { get; set; } = Domain.Enums.MaritalStatus.Single;
    public int? NoOfChildren { get; set; }
    public PhoneNumber? Phone { get; set; }
    public PhoneNumber? AltPhone { get; set; }
    public EmailAddress? Email { get; set; }
    public string? PostGprs { get; set; }
    public PhoneNumber? EmergencyContact { get; set; }
    public string? Hometown { get; set; }
    public int? DistrictId { get; set; }
    public virtual DistrictModel? District { get; set; }
    public virtual HallModel? Hall { get; set; }
    public IdCard? IdCard { get; set; }
    public int? RegionId { get; set; }
    public virtual RegionModel? Region { get; set; }
    public int? NationalityId { get; set; }
    public virtual CountryModel? Nationality { get; set; }
    public bool? ResidentialStatus { get; set; }
    public string? GuardianName { get; set; }
    public PhoneNumber? GuardianPhone { get; set; }
    public string? GuardianOccupation { get; set; }
    public string? GuardianRelationship { get; set; }
    public bool? Disability { get; set; }
    public Disability? DisabilityType { get; set; }
    public string? SourceOfFinance { get; set; }
    public int? ReligionId { get; set; }
    public virtual ReligionModel? Religion { get; set; }
    public string? Denomination { get; set; }
    public string? Referrals { get; set; }
    public Session? EntryMode { get; set; }
    public string? FirstQualification { get; set; }
    public string? SecondQualification { get; set; }
    public string? ProgrammeStudied { get; set; }
    public string? FormerSchool { get; set; }
    public int? FormerSchoolNewId { get; set; }
    public virtual FormerSchoolModel? FormerSchoolNew { get; set; }
    public int? ProgrammeAdmittedId { get; set; }
    public int? LastYearInSchool { get; set; }
    public bool? Awaiting { get; set; }
    public string? IndexNo { get; set; }
    public int? Grade { get; set; }
    public string? YearOfAdmission { get; set; }
    public string? PreferedHall { get; set; }
    public string? Results { get; set; }
    public string? ExternalHostel { get; set; }
    public bool? Elligible { get; set; }
    public bool? Admitted { get; set; }
    public int? AdmittedBy { get; set; }
    public DateTime? DateAdmitted { get; set; }
    public AdmissionType? AdmissionType { get; set; } = Domain.Enums.AdmissionType.Regular;
    public string? leveladmitted { get; set; }
    public string? SectionAdmitted { get; set; }
    public int? HallAdmitted { get; set; }
    public string? RoomNo { get; set; }
    // public string? Status { get; set; }
    public ApplicationStatus? Status { get; set; } = ApplicationStatus.Applicant;
    public bool? SMSSent { get; set; }
    public bool? LetterPrinted { get; set; }
    public int? FirstChoiceId { get; set; }
    public int? SecondChoiceId { get; set; }
    public int? ThirdChoiceId { get; set; }
    public bool? FeePaying { get; set; }
    public bool? ReportedInSchool { get; set; }
    public Money? FeesPaid { get; set; }
    public Money? HallFeesPaid { get; set; }
    public bool? Reported { get; set; }
    public bool? SponsorShip { get; set; }
    public string? SponsorShipCompany { get; set; }
    public string? SponsorShipLocation { get; set; }
    public string? SponsorShipCompanyContact { get; set; }
    public string? ApplicationUserId { get; set; }

    public ApplicantName ChangeName(ApplicantName Name)
    {
        if (object.ReferenceEquals(Name, null))
            throw new ArgumentException("Name must have value", nameof(Name));
        return Name;
    }
    /*[Display(Name = "Full Name")]
    public string FullName => Title +" "+ LastName + ", " + FirstName + " "+ MiddleName;
    */
    public string GetFullName
    {
        get => $"  {this.Title} {this.ApplicantName?.LastName} {this.ApplicantName?.FirstName} {this.ApplicantName?.Othernames}";
    }
    public IEnumerable<DisabilitiesModel>? Disabilities { get; set; }


}

using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.Enums;
using ApplicantPortal.Domain.ValueObjects;

namespace ApplicantPortal.Application.Common.ViewModels;

public class ApplicantVm : IMapFrom<ApplicantModel>
{

    public int Id { get; init; }
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

    public IdCard? Idcard { get; set; }

    public int? RegionId { get; set; }
    public virtual RegionModel? Region { get; set; }
    public int? NationalityId { get; set; }
    public CountryModel? Nationality { get; set; }
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
    public string? EntryMode { get; set; }
    public string? FirstQualification { get; init; }
    public string? SecondQualification { get; init; }
    public string? ProgrammeStudied { get; init; }
    public string? FormerSchool { get; init; }
    public int? FormerSchoolNewId { get; init; }
    public int? ProgrammeAdmittedId { get; init; }
    public int? LastYearInSchool { get; init; }
    public bool? Awaiting { get; init; }
    public string? IndexNo { get; set; }
    public int? Grade { get; init; }
    public string? PreferedHall { get; init; }
    public bool? Elligible { get; init; }
    public bool? Admitted { get; init; }
    public int? AdmittedBy { get; init; }
    public string? AdmissionType { get; init; }
    public string? leveladmitted { get; init; }
    public int? FirstChoiceId { get; init; }
    public int? SecondChoiceId { get; init; }
    public int? ThirdChoiceId { get; init; }
    public bool? SponsorShip { get; init; }
    public string? SponsorShipCompany { get; init; }
    public string? SponsorShipLocation { get; init; }
    public string? SponsorShipCompanyContact { get; init; }
    public string GetFullName
    {
        get => $"  {this.Title} {this.ApplicantName?.LastName} {this.ApplicantName?.FirstName} {this.ApplicantName?.Othernames}";
    }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicantModel, ApplicantVm>()
            .ForMember(d => d.FormerSchool, opt => opt.MapFrom(s => s.FormerSchoolNew))
            .ForMember(d => d.Region, opt => opt.MapFrom(s => s.Region));
    }
    public IEnumerable<ProgrammeModel>? Programmes { get; set; }
    public IEnumerable<ResultUploadModel>? ResultUploads { get; set; }
    public IEnumerable<WorkingExperienceModel>? WorkingExperiences { get; set; }
    public IEnumerable<AcademicExperienceModel>? AcademicExperiences { get; set; }
    public IEnumerable<DocumentUploadModel>? Documents { get; set; }
    public IEnumerable<RefereeModel>? Referees { get; set; }
    public IEnumerable<AddressModel>? Addresses { get; set; }
    public IEnumerable<LanguageModel>? Languages { get; set; }
    public IEnumerable<SMSModel>? Sms { get; set; }
    // public IEnumerable<ApplicantIssueModel>? ApplicantIssues { get; set; }
    public IEnumerable<ResearchModel>? ResearchModels { get; set; }
    public IEnumerable<ResearchPublicationModel>? ResearchPublications { get; set; }
    public IEnumerable<UniversityAttendedModel>? UniversityAttended { get; set; }
    public IEnumerable<SHSAttendedModel>? ShsAttended { get; set; }
    public IEnumerable<DisabilitiesModel>? Disabilities { get; set; }



}

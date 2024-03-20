using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities;

public record ApplicantModel : BaseAuditableEntity
{
    public ApplicationNumber? ApplicationNumber { get; set; }
    public Title Title { set; get; }
    public ApplicantName? ApplicantName { get; set; }
    public ApplicantName? PreviousName { get; set; }
    [DataType(DataType.Date)] public DateOnly Dob { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public MaritalStatus? MaritalStatus { get; set; } = Enums.MaritalStatus.Single;
    public int? NoOfChildren { get; set; }
    public PhoneNumber? Phone { get; set; }
    public PhoneNumber? AltPhone { get; set; }
    public EmailAddress? Email { get; set; }
    public string? PostGprs { get; set; }
    public PhoneNumber? EmergencyContact { get; set; }
    public string? Hometown { get; set; }
    public int? DistrictId { get; set; }
    public DistrictModel? District { get; set; }
    public HallModel? Hall { get; set; }
    public IdCard? IdCard { get; set; }
    public int? RegionId { get; set; }
    public RegionModel? Region { get; set; }
    public int? NationalityId { get; set; }
    public  CountryModel? Nationality { get; set; }
    public bool? ResidentialStatus { get; set; }
    public string? GuardianName { get; set; }
    public PhoneNumber? GuardianPhone { get; set; }
    public string? GuardianOccupation { get; set; }
    public string? GuardianRelationship { get; set; }
    public bool? Disability { get; set; }
    public Disability? DisabilityType { get; set; }
    public string? SourceOfFinance { get; set; }
    public int? ReligionId { get; set; }
    public ReligionModel? Religion { get; set; }
    public string? Denomination { get; set; }
    public string? Referrals { get; set; }
    public Session? EntryMode { get; set; }
    public EntryQualification? FirstQualification { get; set; }
    public EntryQualification? SecondQualification { get; set; }
    public string? ProgrammeStudied { get; set; }
    public string? FormerSchool { get; set; }
    public int? FormerSchoolNewId { get; set; }
    public FormerSchoolModel? FormerSchoolNew { get; set; }
    public int? ProgrammeAdmittedId { get; set; }
    public int? LastYearInSchool { get; set; }
    public bool? Awaiting { get; set; }
    public string? IndexNo { get; set; }
    public int? Grade { get; set; }
    public string? YearOfAdmission { get; set; }
    public string? PreferredHall { get; set; }
    public string? Results { get; set; }
    public string? ExternalHostel { get; set; }
    public bool? Eligible { get; set; }
    public bool? Admitted { get; set; }
    public int? AdmittedBy { get; set; }
    public DateTime? DateAdmitted { get; set; }
    public AdmissionType? AdmissionType { get; set; } = Enums.AdmissionType.Regular;
    public string? LevelAdmitted { get; set; }
    public string? SectionAdmitted { get; set; }
    public int? HallAdmitted { get; set; }
    public string? RoomNo { get; set; }
    public ApplicationStatus? Status { get; set; } = ApplicationStatus.Applicant;
    public bool? ReceivedSms { get; set; }
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
    public string? PreviousIndexNumber { get; set; }
    public static ApplicantName ChangeName(ApplicantName Name)
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
        get =>
            $"  {this.Title} {this.ApplicantName?.LastName} {this.ApplicantName?.FirstName} {this.ApplicantName?.Othernames}";
    }
    public IEnumerable<ProgrammeModel>? Programmes { get; set; }
    public IEnumerable<ResultUploadModel>? ResultUploads { get; set; }
    public IEnumerable<WorkingExperienceModel?>? WorkingExperiences { get; set; }
    public IEnumerable<AcademicExperienceModel?>? AcademicExperiences { get; set; }
    public IEnumerable<DocumentUploadModel?>? Documents { get; set; }
    public IEnumerable<RefereeModel?>? Referees { get; set; }
    public IEnumerable<AddressModel?>? Addresses { get; set; }
    public IEnumerable<LanguageModel?>? Languages { get; set; }
    public IEnumerable<SMSModel>? Sms { get; set; }
    public IEnumerable<ApplicantIssueModel>? ApplicantIssues { get; set; }
    public IEnumerable<ResearchModel>? ResearchModels { get; set; }
    public IEnumerable<ResearchPublicationModel>? ResearchPublications { get; set; }
    public IEnumerable<UniversityAttendedModel>? UniversityAttended { get; set; }
    public IEnumerable<SHSAttendedModel>? ShsAttended { get; set; }
    public IEnumerable<DisabilitiesModel>? Disabilities { get; set; }
}

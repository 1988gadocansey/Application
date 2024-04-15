using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Application.Preview.ExportPdf;

public class ExportApplicantFileRecord : IMapFrom<ApplicantModel>

{
    /*public ExportApplicantFileRecord(long applicationNumber, string firstName, string lastName, string otherName, Gender gender, DateOnly dob, Title title, MaritalStatus? maritalStatus, string phone, string? altPhone, string? email, string? postGprs, string? emergencyContact, string? hometown, int? district, IdCards? nationalIdType, int? regionId, int? nationalityId, bool? residentialStatus, string? guardianName, string? guardianPhone, string? guardianOccupation, string? guardianRelationship, bool? disability, Disability? disabilityType, string? sourceOfFinance, int? religionId, string? denomination, string? referrals, Session? entryMode, string? firstQualification, string? secondQualification, string? programmeStudied, string? formerSchool, int? formerSchoolNewId, int? programmeAdmittedId, int? lastYearInSchool, bool? awaiting, int? grade, string? preferredHall, bool? eligible, bool? admitted, int? admittedBy, string? admissionType, string? levelAdmitted, int? firstChoiceId, int? secondChoiceId, int? thirdChoiceId, bool? sponsorShip, string? sponsorShipCompany, string? sponsorShipLocation, string? sponsorShipCompanyContact)
    {
        ApplicationNumber = applicationNumber;
        FirstName = firstName;
        LastName = lastName;
        OtherName = otherName;
        Gender = gender;
        Dob = dob;
        Title = title;
        MaritalStatus = maritalStatus;
        Phone = phone;
        AltPhone = altPhone;
        Email = email;
        PostGPRS = postGprs;
        EmergencyContact = emergencyContact;
        Hometown = hometown;
        District = district;
        NationalIdType = nationalIdType;
        RegionId = regionId;
        NationalityId = nationalityId;
        ResidentialStatus = residentialStatus;
        GuardianName = guardianName;
        GuardianPhone = guardianPhone;
        GuardianOccupation = guardianOccupation;
        GuardianRelationship = guardianRelationship;
        Disability = disability;
        DisabilityType = disabilityType;
        SourceOfFinance = sourceOfFinance;
        ReligionId = religionId;
        Denomination = denomination;
        Referrals = referrals;
        EntryMode = entryMode;
        FirstQualification = firstQualification;
        SecondQualification = secondQualification;
        ProgrammeStudied = programmeStudied;
        FormerSchool = formerSchool;
        FormerSchoolNewId = formerSchoolNewId;
        ProgrammeAdmittedId = programmeAdmittedId;
        LastYearInSchool = lastYearInSchool;
        Awaiting = awaiting;
        Grade = grade;
        PreferredHall = preferredHall;
        Eligible = eligible;
        Admitted = admitted;
        AdmittedBy = admittedBy;
        AdmissionType = admissionType;
        LevelAdmitted = levelAdmitted;
        FirstChoiceId = firstChoiceId;
        SecondChoiceId = secondChoiceId;
        ThirdChoiceId = thirdChoiceId;
        SponsorShip = sponsorShip;
        SponsorShipCompany = sponsorShipCompany;
        SponsorShipLocation = sponsorShipLocation;
        SponsorShipCompanyContact = sponsorShipCompanyContact;
    }*/

    public long ApplicationNumber { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? OtherName { get; init; }
    public Gender Gender { get; init; }
    public DateOnly Dob { get; init; }
    public Title Title { get; init; }
    public MaritalStatus? MaritalStatus { get; set; }
    public string? Phone { get; init; }
    public string? AltPhone { get; init; }
    public string? Email { get; init; }
    public string? PostGPRS { get; init; }
    public string? EmergencyContact { get; init; }
    public string? Hometown { get; init; }
    public int? District { get; init; }
    public IdCards? NationalIdType { get; init; }
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
    public int? ReligionId { get; init; }
    public string? Denomination { get; init; }
    public string? Referrals { get; init; }
    public Session? EntryMode { get; init; }
    public string? FirstQualification { get; init; }
    public string? SecondQualification { get; init; }
    public string? ProgrammeStudied { get; init; }
    public string? FormerSchool { get; init; }
    public int? FormerSchoolNewId { get; init; }
    public int? ProgrammeAdmittedId { get; init; }
    public int? LastYearInSchool { get; init; }
    public bool? Awaiting { get; init; }
    public int? Grade { get; init; }
    public string? PreferredHall { get; init; }
    public bool? Eligible { get; init; }
    public bool? Admitted { get; init; }
    public int? AdmittedBy { get; init; }
    public string? AdmissionType { get; init; }
    public string? LevelAdmitted { get; init; }
    public int? FirstChoiceId { get; init; }
    public int? SecondChoiceId { get; init; }
    public int? ThirdChoiceId { get; init; }
    public bool? SponsorShip { get; init; }
    public string? SponsorShipCompany { get; init; }
    public string? SponsorShipLocation { get; init; }
    public string? SponsorShipCompanyContact { get; init; }


}

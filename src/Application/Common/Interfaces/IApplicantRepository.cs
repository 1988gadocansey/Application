using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Interfaces;

public interface IApplicantRepository
{
    public Task<ApplicantVm> GetApplicantForUser(string? Id, CancellationToken cancellationToken);

    //public Task<ApplicantIssueDto> GetIssuesForUser(int Applicant, CancellationToken cancellationToken);
    public Task<ApplicantVm> GetApplicant(string UserId, CancellationToken cancellationToken);

    // public Task<bool> SendSMSNotification(string phoneNumber, string message, long formNo, string appSender);
    // public Task SendEmailNotification(string Email, string Message);
    public Task<bool> ContainsDuplicates(IEnumerable<int> data);
    public Task<int> GetAge(DateOnly dateOfBirth);
    public int GetGrade(string applicant);
    public Task<bool> QualifiesMature(int age);
    public int CheckFailed(List<int> gradeValues);
    public int CheckPassed(List<int> gradeValues);
    public string[] GradesIssues(List<int> cores, List<int> coreAlt, List<int> electives);
    public int GetTotalAggregate(List<int> cores, List<int> coreAlt, List<int> electives);
    public Task<string> GetFormNo();
    public Task<ProgressDto> GetProgress(string applicant, CancellationToken cancellationToken);
    public Task<int> UpdateFormNo(CancellationToken cancellationToken);

    // for future use.. applicant has many addresses but now ive limited it to single address cos of time constraints
    public Task<IEnumerable<AddressDto>> GetAddresses(int applicant, CancellationToken cancellationToken);

    //public Task<AddressDto> GetAddresses(int applicant, CancellationToken cancellationToken);
    public Task<SHSAttendedDto> GetSingleShsAttended(int applicant, CancellationToken cancellationToken);
    public Task<UniversityAttendedDto> GetSingleUniversityAttended(int applicant, CancellationToken cancellationToken);
    public Task<IEnumerable<ReligionDto>> Religions(CancellationToken cancellationToken);
    public Task<IEnumerable<CountryDto>> Countries(CancellationToken cancellationToken);
    public Task<IEnumerable<RegionDto>> Regions(CancellationToken cancellationToken);
    public Task<IEnumerable<DistrictDto>> Districts(CancellationToken cancellationToken);
    public Task<IEnumerable<DenominationDto>> Denominations(CancellationToken cancellationToken);
    public Task<IEnumerable<HallDto>> Halls(CancellationToken cancellationToken);
    public Task<IEnumerable<ExamDto>> Exams(CancellationToken cancellationToken);
    public Task<IEnumerable<FormerSchoolDto>> Schools(CancellationToken cancellationToken);
    public Task<IEnumerable<ProgrammeDto>> Programmes(string formType);
    public Task<IEnumerable<SubjectDto>> Subjects(CancellationToken cancellationToken);
    public Task<IEnumerable<GradeDto>> Grades(CancellationToken cancellationToken);
    public Task<IEnumerable<LanguageDto>> Languages(CancellationToken cancellationToken);
    public Task<IEnumerable<DisabilitiesDto>> Disabilities(CancellationToken cancellationToken);
    public Task<IEnumerable<SHSProgrammesDto>> ShsProgrammes(CancellationToken cancellationToken);
    public Task<IEnumerable<UniversityAttendedDto>> UniversityAttended(CancellationToken cancellationToken);
    public Task<IEnumerable<SHSAttendedDto>> ShsAttended(CancellationToken cancellationToken);
    public Task<ConfigurationModel?> GetConfiguration();
    public Task<ApplicantVm> GetApplicantByApplicationNumber(long applicationNumber, CancellationToken cancellationToken);
}

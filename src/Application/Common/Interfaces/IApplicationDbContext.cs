using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<ApplicantModel> ApplicantModels { get; }
    DbSet<ConfigurationModel> ConfigurationModels { get; }
    DbSet<ResultUploadModel> ResultUploadModels { get; }
    DbSet<Choices> Choices { get; }
    DbSet<AcademicExperienceModel> AcademicExperienceModels { get; }
    DbSet<WorkingExperienceModel> WorkingExperienceModels { get; }
    DbSet<ResearchModel> ResearchModels { get; }
    DbSet<ResearchPublicationModel> ResearchPublicationModels { get; }
    DbSet<AddressModel> AddressModels { get; }
    DbSet<ProgressModel> ProgressModels { get; }
    DbSet<ApplicantIssueModel> ApplicantIssueModels { get; }
    DbSet<FormNoModel> FormNoModels { get; }
    DbSet<RegionModel> RegionModels { get; }
    DbSet<ReligionModel> ReligionModels { get; }
    DbSet<RefereeModel> RefereeModels { get; }
    DbSet<ProgrammeModel> ProgrammeModels { get; }
    DbSet<DistrictModel> DistrictModels { get; }
    DbSet<CountryModel> CountryModels { get; }
    DbSet<HallModel> HallModels { get; }
    DbSet<SubjectModel> SubjectModels { get; }
    DbSet<ExamModel> ExamModels { get; }
    DbSet<FormerSchoolModel> FormerSchoolModels { get; }
    DbSet<DenominationModel> DenominationModels { get; }
    DbSet<GradeModel> GradeModels { get; }
    DbSet<DisabilitiesModel> DisabilitiesModels { get; }
    DbSet<LanguageModel> Languages { get; }
    DbSet<SMSModel> SmsModels { get; }
    DbSet<DocumentUploadModel> DocumentUploadModels { get; }
    DbSet<SHSProgrammes> ShsProgrammes { get; }
    DbSet<SHSAttendedModel> ShsAttendedModels { get; }
    DbSet<UniversityAttendedModel> UniversityAttendedModels { get; }
    DbSet<UniversityModel> UniversityModels { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

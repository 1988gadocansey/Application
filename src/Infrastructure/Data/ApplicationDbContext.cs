using System.Reflection;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicantPortal.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Choices> Choices => Set<Choices>();
    public DbSet<RefereeModel> RefereeModels => Set<RefereeModel>();
    public DbSet<ApplicantModel> ApplicantModels => Set<ApplicantModel>();
    public DbSet<ConfigurationModel> ConfigurationModels => Set<ConfigurationModel>();
    public DbSet<ResearchPublicationModel> ResearchPublicationModels => Set<ResearchPublicationModel>();
    public DbSet<FormNoModel> FormNoModels => Set<FormNoModel>();
    public DbSet<AcademicExperienceModel> AcademicExperienceModels => Set<AcademicExperienceModel>();
    public DbSet<BankModel> BankModels => Set<BankModel>();
    public DbSet<FormerSchoolModel> FormerSchoolModels => Set<FormerSchoolModel>();
    public DbSet<DenominationModel> DenominationModels => Set<DenominationModel>();
    public DbSet<DepartmentModel> DepartmentModels => Set<DepartmentModel>();
    public DbSet<DistrictModel> DistrictModels => Set<DistrictModel>();
    public DbSet<DocumentUploadModel> DocumentUploadModels => Set<DocumentUploadModel>();
    public DbSet<ExamModel> ExamModels => Set<ExamModel>();
    public DbSet<FacultyModel> FacultyModels => Set<FacultyModel>();
    public DbSet<HallModel> HallModels => Set<HallModel>();
    public DbSet<RegionModel> RegionModels => Set<RegionModel>();
    public DbSet<ReligionModel> ReligionModels => Set<ReligionModel>();
    public DbSet<RequirementModel> RequirementModels => Set<RequirementModel>();
    public DbSet<SchoolModel> SchoolModels => Set<SchoolModel>();
    public DbSet<SMSModel> SmsModels => Set<SMSModel>();
    public DbSet<SubjectModel> SubjectModels => Set<SubjectModel>();
    public DbSet<SHSProgrammes> ShsProgrammes => Set<SHSProgrammes>();
    public DbSet<CountryModel> CountryModels => Set<CountryModel>();
    public DbSet<AddressModel> AddressModels => Set<AddressModel>();
    public DbSet<LanguageModel> Languages => Set<LanguageModel>();
    public DbSet<ProgrammeModel> ProgrammeModels => Set<ProgrammeModel>();
    public DbSet<ResultUploadModel> ResultUploadModels => Set<ResultUploadModel>();
    public DbSet<WorkingExperienceModel> WorkingExperienceModels => Set<WorkingExperienceModel>();
    public DbSet<ProgressModel> ProgressModels => Set<ProgressModel>();
    public DbSet<ApplicantIssueModel> ApplicantIssueModels => Set<ApplicantIssueModel>();
    public DbSet<ResearchPublicationModel> ResearchPublications => Set<ResearchPublicationModel>();
    public DbSet<ResearchModel> ResearchModels => Set<ResearchModel>();
    public DbSet<UniversityModel> UniversityModels => Set<UniversityModel>();
    public DbSet<GradeModel> GradeModels => Set<GradeModel>();
    public DbSet<DisabilitiesModel> DisabilitiesModels => Set<DisabilitiesModel>();
    public DbSet<UniversityAttendedModel> UniversityAttendedModels => Set<UniversityAttendedModel>();
    public DbSet<SHSAttendedModel> ShsAttendedModels => Set<SHSAttendedModel>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}

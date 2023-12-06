using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplicantPortal.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FormNo = table.Column<string>(type: "text", nullable: true),
                    Started = table.Column<bool>(type: "boolean", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    VoucherType = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Sold = table.Column<bool>(type: "boolean", nullable: false),
                    SoldBy = table.Column<string>(type: "text", nullable: true),
                    Branch = table.Column<string>(type: "text", nullable: true),
                    Teller = table.Column<string>(type: "text", nullable: true),
                    TellerPhone = table.Column<string>(type: "text", nullable: true),
                    FormCompleted = table.Column<bool>(type: "boolean", nullable: true),
                    PictureUploaded = table.Column<bool>(type: "boolean", nullable: true),
                    Finalized = table.Column<bool>(type: "boolean", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    ResultUploaded = table.Column<bool>(type: "boolean", nullable: true),
                    Admitted = table.Column<bool>(type: "boolean", nullable: false),
                    Pin = table.Column<string>(type: "text", nullable: true),
                    ForeignApplicant = table.Column<bool>(type: "boolean", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Account = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<string>(type: "text", nullable: true),
                    OrientationStarts = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrientationEnds = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Matriculation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Reporting = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FeesDeadline = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MedicalStarts = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MedicalEnds = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdmissionsOfficer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DenominationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenominationModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistrictModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CutOffPoint = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormerSchoolModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormerSchoolModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormNoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    No = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormNoModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HallModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankAccount = table.Column<int>(type: "integer", nullable: false),
                    Fees = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgressModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    Biodata = table.Column<bool>(type: "boolean", nullable: true),
                    Results = table.Column<bool>(type: "boolean", nullable: false),
                    Picture = table.Column<bool>(type: "boolean", nullable: false),
                    Age = table.Column<bool>(type: "boolean", nullable: false),
                    FormCompletion = table.Column<bool>(type: "boolean", nullable: false),
                    Qualification = table.Column<bool>(type: "boolean", nullable: false),
                    DocumentUpload = table.Column<bool>(type: "boolean", nullable: true),
                    WorkingExperience = table.Column<bool>(type: "boolean", nullable: true),
                    AcademicExperience = table.Column<bool>(type: "boolean", nullable: true),
                    ResearchInformation = table.Column<bool>(type: "boolean", nullable: true),
                    ResearchPublication = table.Column<bool>(type: "boolean", nullable: true),
                    Referee = table.Column<bool>(type: "boolean", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReligionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequirementModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Department = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: true),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    RuleOne = table.Column<string>(type: "text", nullable: true),
                    RuleTwo = table.Column<string>(type: "text", nullable: true),
                    RuleThree = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShsProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShsProgrammes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Colour_Code = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    University = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    FacultyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentModels_FacultyModels_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchoolModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolModels_RegionModels_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationNumber = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Othernames = table.Column<string>(type: "text", nullable: true),
                    PreviousFirstName = table.Column<string>(type: "text", nullable: true),
                    PreviousLastName = table.Column<string>(type: "text", nullable: true),
                    PreviousOthernames = table.Column<string>(type: "text", nullable: true),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    NoOfChildren = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    AltPhone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PostGprs = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<string>(type: "text", nullable: false),
                    Hometown = table.Column<string>(type: "text", nullable: true),
                    DistrictId = table.Column<int>(type: "integer", nullable: true),
                    HallId = table.Column<int>(type: "integer", nullable: true),
                    NationalIDType = table.Column<string>(type: "text", nullable: true),
                    NationalIDNo = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: true),
                    NationalityId = table.Column<int>(type: "integer", nullable: true),
                    ResidentialStatus = table.Column<bool>(type: "boolean", nullable: true),
                    GuardianName = table.Column<string>(type: "text", nullable: true),
                    GuardianPhone = table.Column<string>(type: "text", nullable: false),
                    GuardianOccupation = table.Column<string>(type: "text", nullable: true),
                    GuardianRelationship = table.Column<string>(type: "text", nullable: true),
                    Disability = table.Column<bool>(type: "boolean", nullable: true),
                    DisabilityType = table.Column<int>(type: "integer", nullable: true),
                    SourceOfFinance = table.Column<string>(type: "text", nullable: true),
                    ReligionId = table.Column<int>(type: "integer", nullable: true),
                    Denomination = table.Column<string>(type: "text", nullable: true),
                    Referrals = table.Column<string>(type: "text", nullable: true),
                    EntryMode = table.Column<string>(type: "text", nullable: true),
                    FirstQualification = table.Column<string>(type: "text", nullable: true),
                    SecondQualification = table.Column<string>(type: "text", nullable: true),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: true),
                    FormerSchool = table.Column<string>(type: "text", nullable: true),
                    FormerSchoolNewId = table.Column<int>(type: "integer", nullable: true),
                    ProgrammeAdmittedId = table.Column<int>(type: "integer", nullable: true),
                    LastYearInSchool = table.Column<int>(type: "integer", nullable: true),
                    Awaiting = table.Column<bool>(type: "boolean", nullable: true),
                    IndexNo = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: true),
                    YearOfAdmission = table.Column<string>(type: "text", nullable: true),
                    PreferredHall = table.Column<string>(type: "text", nullable: true),
                    Results = table.Column<string>(type: "text", nullable: true),
                    ExternalHostel = table.Column<string>(type: "text", nullable: true),
                    Eligible = table.Column<bool>(type: "boolean", nullable: true),
                    Admitted = table.Column<bool>(type: "boolean", nullable: true),
                    AdmittedBy = table.Column<int>(type: "integer", nullable: true),
                    DateAdmitted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AdmissionType = table.Column<string>(type: "text", nullable: true),
                    LevelAdmitted = table.Column<string>(type: "text", nullable: true),
                    SectionAdmitted = table.Column<string>(type: "text", nullable: true),
                    HallAdmitted = table.Column<int>(type: "integer", nullable: true),
                    RoomNo = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true, defaultValue: "Applicant"),
                    ReceivedSms = table.Column<bool>(type: "boolean", nullable: true),
                    LetterPrinted = table.Column<bool>(type: "boolean", nullable: true),
                    FirstChoiceId = table.Column<int>(type: "integer", nullable: true),
                    SecondChoiceId = table.Column<int>(type: "integer", nullable: true),
                    ThirdChoiceId = table.Column<int>(type: "integer", nullable: true),
                    FeePaying = table.Column<bool>(type: "boolean", nullable: true),
                    ReportedInSchool = table.Column<bool>(type: "boolean", nullable: true),
                    FeesPaidCurrency = table.Column<string>(type: "text", nullable: true),
                    FeesPaid = table.Column<decimal>(type: "numeric", nullable: true),
                    HallFeesPaidCurrency = table.Column<string>(type: "text", nullable: true),
                    HallFeesPaid = table.Column<decimal>(type: "numeric", nullable: true),
                    Reported = table.Column<bool>(type: "boolean", nullable: true),
                    SponsorShip = table.Column<bool>(type: "boolean", nullable: true),
                    SponsorShipCompany = table.Column<string>(type: "text", nullable: true),
                    SponsorShipLocation = table.Column<string>(type: "text", nullable: true),
                    SponsorShipCompanyContact = table.Column<string>(type: "text", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantModel_CountryModels_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "CountryModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_DistrictModels_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DistrictModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_FormerSchoolModels_FormerSchoolNewId",
                        column: x => x.FormerSchoolNewId,
                        principalTable: "FormerSchoolModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_HallModels_HallId",
                        column: x => x.HallId,
                        principalTable: "HallModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_RegionModels_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_ReligionModels_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Reminder = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Done = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    LevelAdmitted = table.Column<string>(type: "text", nullable: true),
                    Running = table.Column<bool>(type: "boolean", nullable: false),
                    ShowOnPortal = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    Affiliation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammeModels_DepartmentModels_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademicExperienceModels",
                columns: table => new
                {
                    InstitutionName = table.Column<string>(type: "text", nullable: false),
                    InstitutionAddress = table.Column<string>(type: "text", nullable: true),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Certificate = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicExperienceModels", x => x.InstitutionName);
                    table.ForeignKey(
                        name: "FK_AcademicExperienceModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Gprs = table.Column<string>(type: "text", nullable: true),
                    Box = table.Column<string>(type: "text", nullable: true),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressModels_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantIssueModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantId = table.Column<int>(type: "integer", nullable: false),
                    Issue = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantIssueModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantIssueModels_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisabilitiesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilitiesModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabilitiesModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentUploadModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUploadModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentUploadModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefereeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Institution = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: true),
                    RefereeStatus = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefereeModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResearchModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Month = table.Column<string>(type: "text", nullable: true),
                    AreaOfResearchIfAdmitted = table.Column<string>(type: "text", nullable: true),
                    ActualAreaOfResearch = table.Column<string>(type: "text", nullable: true),
                    FutureResearchInterest = table.Column<string>(type: "text", nullable: true),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchModels_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResearchPublicationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true),
                    Publication = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchPublicationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchPublicationModel_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultUploadModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    ExamType = table.Column<string>(type: "text", nullable: true),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    GradeOld = table.Column<int>(type: "integer", nullable: true),
                    GradeValueOld = table.Column<string>(type: "text", nullable: true),
                    IndexNo = table.Column<string>(type: "text", nullable: true),
                    Sitting = table.Column<string>(type: "text", nullable: true),
                    Month = table.Column<string>(type: "text", nullable: true),
                    Form = table.Column<int>(type: "integer", nullable: false),
                    Center = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    OldSubject = table.Column<string>(type: "text", nullable: true),
                    InstitutionName = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultUploadModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultUploadModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultUploadModels_GradeModels_GradeId",
                        column: x => x.GradeId,
                        principalTable: "GradeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultUploadModels_SubjectModels_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShsAttendedModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttendedTTU = table.Column<bool>(type: "boolean", nullable: false),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true),
                    NameId = table.Column<int>(type: "integer", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: true),
                    StartYear = table.Column<int>(type: "integer", nullable: true),
                    EndYear = table.Column<int>(type: "integer", nullable: true),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShsAttendedModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShsAttendedModels_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShsAttendedModels_FormerSchoolModels_NameId",
                        column: x => x.NameId,
                        principalTable: "FormerSchoolModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShsAttendedModels_RegionModels_LocationId",
                        column: x => x.LocationId,
                        principalTable: "RegionModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SmsModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: true),
                    SentBy = table.Column<string>(type: "text", nullable: true),
                    Recipient = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UniversityAttendedModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: true),
                    StartYear = table.Column<string>(type: "text", nullable: true),
                    EndYear = table.Column<string>(type: "text", nullable: true),
                    StudentNumber = table.Column<string>(type: "text", nullable: true),
                    DegreeObtained = table.Column<string>(type: "text", nullable: true),
                    DegreeClassification = table.Column<string>(type: "text", nullable: true),
                    CGPA = table.Column<decimal>(type: "numeric", nullable: true),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityAttendedModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityAttendedModels_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UniversityAttendedModels_CountryModels_LocationId",
                        column: x => x.LocationId,
                        principalTable: "CountryModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkingExperienceModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    CompanyPhone = table.Column<string>(type: "text", nullable: true),
                    CompanyAddress = table.Column<string>(type: "text", nullable: true),
                    CompanyPosition = table.Column<string>(type: "text", nullable: true),
                    CompanyFrom = table.Column<string>(type: "text", nullable: true),
                    CompanyTo = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingExperienceModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingExperienceModels_ApplicantModel_ApplicantModelId",
                        column: x => x.ApplicantModelId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantModelProgrammeModel",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantModelProgrammeModel", x => new { x.ApplicantId, x.ProgrammesId });
                    table.ForeignKey(
                        name: "FK_ApplicantModelProgrammeModel_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantModelProgrammeModel_ProgrammeModels_ProgrammesId",
                        column: x => x.ProgrammesId,
                        principalTable: "ProgrammeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true),
                    FirstChoiceId = table.Column<int>(type: "integer", nullable: true),
                    SecondChoiceId = table.Column<int>(type: "integer", nullable: true),
                    ThirdChoiceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_ApplicantModel_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "ApplicantModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Choices_ProgrammeModels_FirstChoiceId",
                        column: x => x.FirstChoiceId,
                        principalTable: "ProgrammeModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Choices_ProgrammeModels_SecondChoiceId",
                        column: x => x.SecondChoiceId,
                        principalTable: "ProgrammeModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Choices_ProgrammeModels_ThirdChoiceId",
                        column: x => x.ThirdChoiceId,
                        principalTable: "ProgrammeModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicExperienceModels_ApplicantModelId",
                table: "AcademicExperienceModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressModels_ApplicantId",
                table: "AddressModels",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssueModels_ApplicantId",
                table: "ApplicantIssueModels",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_FormerSchoolNewId",
                table: "ApplicantModel",
                column: "FormerSchoolNewId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_HallId",
                table: "ApplicantModel",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_NationalityId",
                table: "ApplicantModel",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModelProgrammeModel_ProgrammesId",
                table: "ApplicantModelProgrammeModel",
                column: "ProgrammesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ApplicantId",
                table: "Choices",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_FirstChoiceId",
                table: "Choices",
                column: "FirstChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_SecondChoiceId",
                table: "Choices",
                column: "SecondChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ThirdChoiceId",
                table: "Choices",
                column: "ThirdChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentModels_FacultyId",
                table: "DepartmentModels",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilitiesModels_ApplicantModelId",
                table: "DisabilitiesModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUploadModels_ApplicantModelId",
                table: "DocumentUploadModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ApplicantModelID",
                table: "Languages",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModels_DepartmentId",
                table: "ProgrammeModels",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RefereeModels_ApplicantModelId",
                table: "RefereeModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchModels_ApplicantId",
                table: "ResearchModels",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchPublicationModel_ApplicantId",
                table: "ResearchPublicationModel",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModels_ApplicantModelId",
                table: "ResultUploadModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModels_GradeId",
                table: "ResultUploadModels",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModels_SubjectId",
                table: "ResultUploadModels",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolModels_RegionId",
                table: "SchoolModels",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShsAttendedModels_ApplicantId",
                table: "ShsAttendedModels",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ShsAttendedModels_LocationId",
                table: "ShsAttendedModels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShsAttendedModels_NameId",
                table: "ShsAttendedModels",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsModels_ApplicantModelId",
                table: "SmsModels",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendedModels_ApplicantId",
                table: "UniversityAttendedModels",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendedModels_LocationId",
                table: "UniversityAttendedModels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperienceModels_ApplicantModelId",
                table: "WorkingExperienceModels",
                column: "ApplicantModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicExperienceModels");

            migrationBuilder.DropTable(
                name: "AddressModels");

            migrationBuilder.DropTable(
                name: "ApplicantIssueModels");

            migrationBuilder.DropTable(
                name: "ApplicantModelProgrammeModel");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankModels");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "ConfigurationModels");

            migrationBuilder.DropTable(
                name: "DenominationModels");

            migrationBuilder.DropTable(
                name: "DisabilitiesModels");

            migrationBuilder.DropTable(
                name: "DocumentUploadModels");

            migrationBuilder.DropTable(
                name: "ExamModels");

            migrationBuilder.DropTable(
                name: "FormNoModels");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProgressModels");

            migrationBuilder.DropTable(
                name: "RefereeModels");

            migrationBuilder.DropTable(
                name: "RequirementModels");

            migrationBuilder.DropTable(
                name: "ResearchModels");

            migrationBuilder.DropTable(
                name: "ResearchPublicationModel");

            migrationBuilder.DropTable(
                name: "ResultUploadModels");

            migrationBuilder.DropTable(
                name: "SchoolModels");

            migrationBuilder.DropTable(
                name: "ShsAttendedModels");

            migrationBuilder.DropTable(
                name: "ShsProgrammes");

            migrationBuilder.DropTable(
                name: "SmsModels");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "UniversityAttendedModels");

            migrationBuilder.DropTable(
                name: "UniversityModels");

            migrationBuilder.DropTable(
                name: "WorkingExperienceModels");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProgrammeModels");

            migrationBuilder.DropTable(
                name: "GradeModels");

            migrationBuilder.DropTable(
                name: "SubjectModels");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "ApplicantModel");

            migrationBuilder.DropTable(
                name: "DepartmentModels");

            migrationBuilder.DropTable(
                name: "CountryModels");

            migrationBuilder.DropTable(
                name: "DistrictModels");

            migrationBuilder.DropTable(
                name: "FormerSchoolModels");

            migrationBuilder.DropTable(
                name: "HallModels");

            migrationBuilder.DropTable(
                name: "RegionModels");

            migrationBuilder.DropTable(
                name: "ReligionModels");

            migrationBuilder.DropTable(
                name: "FacultyModels");
        }
    }
}

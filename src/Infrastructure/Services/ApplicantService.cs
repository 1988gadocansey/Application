using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Infrastructure.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicantPortal.Infrastructure.Services;

public class ApplicantService(
    IApplicationDbContext context,
    IMapper mapper
    
) : IApplicantRepository
{
    public int CheckFailed(List<int> GradeValues) => GradeValues.Count(values => values > 7);
    public int CheckPassed(List<int> GradeValues) => GradeValues.Count(values => values < 7);

    public Task<bool> ContainsDuplicates(IEnumerable<int> results)
    {
        IEnumerable<int> enumerable = results as int[] ?? results.ToArray();
        return enumerable.Count() != enumerable.Distinct().Count() ? Task.FromResult(true) : Task.FromResult(false);
    }

    public Task<int> GetAge(DateOnly dateOfBirth)
    {
        var today = DateTime.Today;
        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;
        var age = (a - b) / 10000;
        return Task.FromResult(age);
    }

    public async Task<ApplicantVm> GetApplicant(string UserId, CancellationToken cancellationToken)
    {
        var applicant = await context.ApplicantModels
            .Include(a => a.Addresses)
            .Include(a => a.UniversityAttended)
            .Include(a => a.ShsAttended)
            .FirstOrDefaultAsync(a => a.ApplicationUserId == UserId, cancellationToken);
        var applicantDetails = mapper.Map<ApplicantVm>(applicant);
        return applicantDetails;
    }

    public async Task<ApplicantVm> GetApplicantByApplicationNumber(long ApplicationNumber,
        CancellationToken cancellationToken)
    {
        var applicant =
            await context.ApplicantModels.FirstOrDefaultAsync(
                a => a.ApplicationNumber!.ApplicantNumber == ApplicationNumber, cancellationToken);
        var applicantDetails = mapper.Map<ApplicantVm>(applicant);
        return applicantDetails;
    }

    public async Task<ApplicantVm> GetApplicantForUser(string? Id, CancellationToken cancellationToken)
    {
        var applicant =
            await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == Id, cancellationToken);
        var applicantDetails = mapper.Map<ApplicantVm>(applicant);
        return applicantDetails;
    }

    

    public async Task<ConfigurationModel?> GetConfiguration()
    {
        return await context.ConfigurationModels.OrderByDescending(b => b.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<string> GetFormNo()
    {
        var configuration = await context.ConfigurationModels.OrderByDescending(b => b.Id)
            .FirstOrDefaultAsync();
        var formNumber = await context.FormNoModels.FirstAsync(n => n.Year == configuration!.Year);
        return formNumber.No.ToString();
    }

    public int GetTotalAggregate(List<int> Cores, List<int> CoreAlt, List<int> Electives)
    {
        CoreAlt.Sort();
        Cores.Sort();
        Electives.Sort();
        var CstartIndex = 0;
        var Clenght = 1;
        var SliceCoreAlt = CoreAlt.Skip(CstartIndex).Take(Clenght) ??
                           throw new ArgumentNullException("CoreAlt.Skip(CstartIndex).Take(Clenght)");
        const int EstartIndex = 0;
        const int Elenght = 3;
        var SliceElect = Electives.Skip(EstartIndex).Take(Elenght);
        var grade = Cores.Sum() + SliceElect.Sum() + SliceCoreAlt.Sum();
        return grade;
    }

    public async Task<ProgressDto> GetProgress(string Applicant, CancellationToken cancellationToken)
    {
        var data = await context.ProgressModels.FirstOrDefaultAsync(a => a.ApplicationUserId == Applicant,
            cancellationToken: cancellationToken);
        return mapper.Map<ProgressDto>(data);
    }

    public string[] GradesIssues(List<int> Cores, List<int> CoreAlt, List<int> Electives)
    {
        //IEnumerable<string> error = new []{ ""} ;
        var error = new[] { "" };
        /*
        var user = await _userManager.FindByIdAsync(userId);
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
        var results = _context.ResultUploadModels.Where(a => a.ApplicantModelID == applicant.Id);
        */
        if (Cores.Count + CoreAlt.Count() + Electives.Count() != 6)
        {
            const string msg = "Results not completed.";
            Array.Fill(error, msg);
        }
        else if (Cores.Count < 2)
        {
            const string msg = "Minimum of two(2) core subjects not met.";
            Array.Fill(error, msg);
        }
        else if (Electives.Count < 3)
        {
            const string msg = "Minimum of three(3) elective subjects not met.";
            Array.Fill(error, msg);
        }
        else if (CoreAlt.Count == 0)
        {
            const string msg = "Social or Science required.";
            Array.Fill(error, msg);
        }
        else
        {
            string msg = null!;
            Array.Fill(error, msg);
        }

        return error;
    }

    public async Task<bool> QualifiesMature(int age)
    {
        return await Task.FromResult((age >= 25));
    }

    public int GetGrade(string Applicant)
    {
        var data = context.ApplicantModels.FirstOrDefault(a => a.ApplicationUserId == Applicant);
        if (data != null)
        {
            return (int)data.Grade!;
        }

        return 0;
    }

    public async Task<int> UpdateFormNo(CancellationToken cancellationToken)
    {
        var configuration = context.ConfigurationModels.OrderByDescending(b => b.Id).FirstOrDefault();
        var update = context.FormNoModels.First(n => n.Year == configuration!.Year);
        update.No += 1;
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<RegionDto>> Regions(CancellationToken cancellationToken)
    {
        var data = await context.RegionModels.OrderBy(a => a.Name).ToListAsync(cancellationToken);
        /* var data = await _context.RegionModels.Select(b =>
        new RegionDto()
        {
            Id = b.Id,
            Name = b.Name,
        }).ToListAsync(cancellationToken: cancellationToken);
        return data; */

        var selectBoxItem = mapper.Map<IEnumerable<RegionDto>>(data);
        return selectBoxItem;
    }

    public async Task<IEnumerable<ReligionDto>> Religions(CancellationToken cancellationToken)
    {
        var data = await context.ReligionModels.OrderBy(a => a.Name).ToListAsync(cancellationToken);
        var selectBoxItem = mapper.Map<IEnumerable<ReligionDto>>(data);
        return selectBoxItem;
    }

    public async Task<IEnumerable<SubjectDto>> Subjects(CancellationToken cancellationToken)
    {
        var data = await context.SubjectModels.OrderBy(a => a.Name).ToListAsync(cancellationToken);
        var selectBoxItem = mapper.Map<IEnumerable<SubjectDto>>(data);
        return selectBoxItem;
    }

    public async Task<IEnumerable<ExamDto>> Exams(CancellationToken cancellationToken)
    {
        var data = await context.ExamModels.OrderBy(a => a.Name).ToListAsync(cancellationToken);
        var selectBoxItem = mapper.Map<IEnumerable<ExamDto>>(data);
        return selectBoxItem;
    }

    public async Task<IEnumerable<FormerSchoolDto>> Schools(CancellationToken cancellationToken)
    {
        var data = await context.FormerSchoolModels.OrderBy(a => a.Name).ToListAsync(cancellationToken);
        var selectBoxItem = mapper.Map<IEnumerable<FormerSchoolDto>>(data);
        return selectBoxItem;
    }

    /*  public ProgrammeModel Programmes(string FormType)
     {
         var data = _context.ProgrammeModels.Where(a => a.Type == FormType).Select(p => new { p.Id, p.Name }).ToList().OrderBy(a => a.Name);

     } */
    public async Task<IEnumerable<ProgrammeDto>> Programmes(string FormType)
    {
        var types = new Dictionary<string, string>
        {
            { "DIPLOMA", "DipTECH" },
            { "MTECH", "MTECH" },
            { "BTECH", "DEGREE" },
            { "MATURE", "BTECH" },
            { "TOPUP", "BTECH" },
            { "BRIDGING", "BTECH" },
            { "CERTIFICATE", "CERT" },
            { "HND", "HND" },
            { "ACCELERATED", "BTECH" }
        };
        var formType = types.FirstOrDefault(x => x.Value == FormType).Value;


        var programme = await context.ProgrammeModels.AsNoTracking()
            .OrderBy(n => n.Name)
            .Where(n => n.Type == formType).ToListAsync();

        return mapper.Map<IEnumerable<ProgrammeDto>>(programme);
    }

    public async Task<IEnumerable<CountryDto>> Countries(CancellationToken cancellationToken)
    {
        var data = await context.CountryModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<CountryDto>>(data);
    }

    public async Task<IEnumerable<DistrictDto>> Districts(CancellationToken cancellationToken)
    {
        var data = await context.DistrictModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<DistrictDto>>(data);
    }

    public async Task<IEnumerable<DenominationDto>> Denominations(CancellationToken cancellationToken)
    {
        var data = await context.DenominationModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<DenominationDto>>(data);
    }

    public async Task<IEnumerable<HallDto>> Halls(CancellationToken cancellationToken)
    {
        var data = await context.HallModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<HallDto>>(data);
    }

    public async Task<IEnumerable<GradeDto>> Grades(CancellationToken cancellationToken)
    {
        var data = await context.GradeModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<GradeDto>>(data);
    }

    public async Task<IEnumerable<SHSProgrammesDto>> SHSProgrammes(CancellationToken cancellationToken)
    {
        var data = await context.ShsProgrammes
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<SHSProgrammesDto>>(data);
    }

    public async Task<IEnumerable<DisabilitiesDto>> Disabilities(CancellationToken cancellationToken)
    {
        var data = await context.DistrictModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<DisabilitiesDto>>(data);
    }

    public Task<IEnumerable<SHSProgrammesDto>> ShsProgrammes(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<LanguageDto>> Languages(CancellationToken cancellationToken)
    {
        var data = await context.Languages
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<LanguageDto>>(data);
    }

    /*  public async Task<IEnumerable<AddressDto>> GetAddresses(int applicant, CancellationToken cancellationToken)
     {
         var data = await _context.AddressModels.Where(a => a.Applicant.Id == applicant).ToListAsync(cancellationToken: cancellationToken);

         return _mapper.Map<IEnumerable<AddressDto>>(data);
     } */
    public async Task<IEnumerable<AddressDto>> GetAddresses(int applicant, CancellationToken cancellationToken)
    {
        var data = await context.AddressModels.FirstOrDefaultAsync(a => a.Applicant!.Id == applicant,
            cancellationToken);

        return mapper.Map<IEnumerable<AddressDto>>(data);
    }

    

    public async Task<SHSAttendedDto> GetSingleShsAttended(int applicant, CancellationToken cancellationToken)
    {
        var data = await context.ShsAttendedModels.Include(a => a.Name).Include(a => a.Location)
            .FirstOrDefaultAsync(a => a.Applicant!.Id == applicant, cancellationToken);

        return mapper.Map<SHSAttendedDto>(data);
    }

    public async Task<UniversityAttendedDto> GetSingleUniversityAttended(int applicant,
        CancellationToken cancellationToken)
    {
        var data = await context.UniversityAttendedModels.FirstOrDefaultAsync(a => a.Applicant!.Id == applicant,
            cancellationToken);

        return mapper.Map<UniversityAttendedDto>(data);
    }

    public async Task<IEnumerable<SHSAttendedDto>> ShsAttended(CancellationToken cancellationToken)
    {
        var data = await context.ShsAttendedModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<SHSAttendedDto>>(data);
    }

    public async Task<IEnumerable<UniversityAttendedDto>> UniversityAttended(CancellationToken cancellationToken)
    {
        var data = await context.UniversityAttendedModels
            .ToListAsync(cancellationToken: cancellationToken);
        return mapper.Map<IEnumerable<UniversityAttendedDto>>(data);
    }
}

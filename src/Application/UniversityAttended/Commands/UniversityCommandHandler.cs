using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.UniversityAttended.Commands;
public class UniversityCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<UniversityAttendedRequest, int>
{
    private readonly IApplicantRepository _applicantRepository = applicantRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(UniversityAttendedRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = context.ApplicantModels.FirstOrDefault(a => a.ApplicationUserId == userId);
        var country = context.CountryModels.FirstOrDefault(a => a.Id == request.Location);
        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id.ToString()!); ;
        var data = new UniversityAttendedModel
        {
            Name = request.Name,
            Location = country,
            Applicant = applicantDetails,
            CGPA = request.CGPA,
            StartYear = request.StartYear,
            EndYear = request.EndYear,
            StudentNumber = request.StudentNumber,
            DegreeObtained = request.DegreeObtained,
            DegreeClassification = request.DegreeClassification
        };
        // var dataMapped = _mapper.Map<UniversityAttendedModel>(data);
        await context.UniversityAttendedModels.AddAsync(data, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}

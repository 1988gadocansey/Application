using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.WorkingExperience.Commands;

public class WorkingExperienceCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<WorkingExperienceRequest, int>
{
    public async Task<int> Handle(WorkingExperienceRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);
        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id.ToString());
        var data = new WorkingExperienceDto
        {
            Applicant = applicantDetails.Id,
            CompanyAddress = request.CompanyAddress,
            CompanyFrom = request.CompanyFrom,
            CompanyName = request.CompanyName,
            CompanyPhone = request.CompanyPhone,
            CompanyPosition = request.CompanyPosition,
            CompanyTo = request.CompanyTo
        };
        var dataMapped = mapper.Map<WorkingExperienceModel>(data);
        await context.WorkingExperienceModels.AddAsync(dataMapped, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}

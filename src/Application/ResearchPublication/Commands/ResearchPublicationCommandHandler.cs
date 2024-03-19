using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.ResearchPublication.Commands;

public class ResearchPublicationCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<ResearchPublicationRequest, int>
{
    public async Task<int> Handle(ResearchPublicationRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);

        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id.ToString()); ;
        var data = new ResearchPublicationDto
        {
            Publication = request.Publication,
            Applicant = applicantDetails.Id
        };
        var dataMapped = mapper.Map<ResearchPublicationModel>(data);
        await context.ResearchPublicationModels.AddAsync(dataMapped, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Referee.Commands;

public class RefereeCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<CreateRefereeRequest, int>
{
    public async Task<int> Handle(CreateRefereeRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);

        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id.ToString()); ;
        var data = new RefereeDto
        {
            Applicant = request.ApplicantModel,
            Institution = request.Institution,
            Name = request.Name,
            Email = request.Email,
            Position = request.Position

        };
        var dataMapped = mapper.Map<RefereeModel>(data);
        await context.RefereeModels.AddAsync(dataMapped, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return request.Id;
    }
}

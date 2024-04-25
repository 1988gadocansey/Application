 
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Application.Preview;
using OnlineApplicationSystem.Application.Preview;

namespace ApplicantPortal.Application.ProgrammeInformation.Queries;

public record GetProgrammeInfoQuery : IRequest<ApplicantVm>;

public class GetProgrammeInfoQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IMapper mapper)
    : IRequestHandler<GetProgrammeInfoQuery, ApplicantVm>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicantVm> Handle(GetProgrammeInfoQuery request, CancellationToken cancellationToken) => await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);
    /* public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
    {
        return await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);
    } */
}

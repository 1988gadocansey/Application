 
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Application.Preview;
using OnlineApplicationSystem.Application.Preview;

namespace ApplicantPortal.Application.ProgrammeInformation.Queries;

public record GetProgrammeInfoQuery : IRequest<ApplicantVm>;

public class GetProgrammeInfoQueryHandler : IRequestHandler<GetApplicantQuery, ApplicantVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IUser _currentUserService;
    private readonly IMapper _mapper;

    public GetProgrammeInfoQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, IUser currentUserService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;

    }

    public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken) => await _applicantRepository.GetApplicantForUser(_currentUserService.Id, cancellationToken);
    /* public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
    {
        return await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);
    } */
}

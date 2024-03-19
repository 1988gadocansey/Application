using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.ViewModels;

namespace ApplicantPortal.Application.Preview;

public record GetApplicantPreviewQuery : IRequest<ApplicantVm>;

public class GetApplicantPreviewQueryHandler : IRequestHandler<GetApplicantQuery, ApplicantVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IUser _currentUserService;
    private readonly IMapper _mapper;

    public GetApplicantPreviewQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, IUser currentUserService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;

    }

    public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken) => await _applicantRepository.GetApplicant(_currentUserService.Id!, cancellationToken);
    
}

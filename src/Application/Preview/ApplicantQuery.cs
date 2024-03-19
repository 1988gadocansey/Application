using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.ViewModels;

namespace ApplicantPortal.Application.Preview;

public abstract record GetApplicantQuery : IRequest<ApplicantVm>;

public class GetApplicantQueryHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IMapper mapper)
    : IRequestHandler<GetApplicantQuery, ApplicantVm>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken) => await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);
     
}

/*
using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.User.Queries;

public record GetProgressQuery : IRequest<ProgressDto>;

public class GetProgressQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository,
    IUser currentUserService, IMapper mapper) : IRequestHandler<GetProgressQuery, ProgressDto>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    public async Task<ProgressDto> Handle(GetProgressQuery request, CancellationToken cancellationToken) => await applicantRepository.GetProgress(currentUserService.Id, cancellationToken);
}
*/

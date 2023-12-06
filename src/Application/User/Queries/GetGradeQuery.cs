/*
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.User.Queries;

public record GetGradeQuery : IRequest<int>;

public class GetGradeQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, IUser currentUserService, IMapper mapper) : IRequestHandler<GetGradeQuery, int>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public Task<int> Handle(GetGradeQuery request, CancellationToken cancellationToken) => Task.FromResult(applicantRepository.GetGrade(currentUserService.Id));
    
}
*/

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

 
public abstract record GetGradeQuery : IRequest<IEnumerable<GradeDto>>;

public class GetGradeQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    : IRequestHandler<GetGradeQuery, IEnumerable<GradeDto>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<GradeDto>> Handle(GetGradeQuery request, CancellationToken cancellationToken) { return await applicantRepository.Grades(cancellationToken); }

}

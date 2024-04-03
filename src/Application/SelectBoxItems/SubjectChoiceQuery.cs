using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;


public   record GetSubjectQuery : IRequest<IEnumerable<SubjectDto>>;

public class GetSubjectQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    : IRequestHandler<GetSubjectQuery, IEnumerable<SubjectDto>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IEnumerable<SubjectDto>> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {
        return await applicantRepository.Subjects(cancellationToken);
        
    }

}

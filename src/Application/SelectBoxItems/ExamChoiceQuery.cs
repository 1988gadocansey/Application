using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

public abstract record GetExamQuery : IRequest<IEnumerable<ExamDto>>;

public class GetExamQueryHandler( IApplicantRepository applicantRepository)
    : IRequestHandler<GetExamQuery, IEnumerable<ExamDto>>
{
    public async Task<IEnumerable<ExamDto>> Handle(GetExamQuery request, CancellationToken cancellationToken)
    {
      return await applicantRepository.Exams(cancellationToken);
       
    }

}

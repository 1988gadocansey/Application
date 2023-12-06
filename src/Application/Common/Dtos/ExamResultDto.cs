using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record ExamResultDto : IMapFrom<ExamModel>
{
    public int? Id { set; get; }
    public int? Exam { set; get; }


}

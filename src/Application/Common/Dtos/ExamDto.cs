using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;

namespace ApplicantPortal.Application.Common.Dtos;
public record ExamDto : IMapFrom<ExamModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }
    public int? CutOffPoint { set; get; }

}

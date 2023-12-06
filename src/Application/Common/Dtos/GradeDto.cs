
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;

namespace ApplicantPortal.Application.Common.Dtos;
public record GradeDto : IMapFrom<GradeModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }
    public decimal? Value { set; get; }

}

using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;
namespace ApplicantPortal.Application.Common.Dtos;
public record SubjectDto : IMapFrom<SubjectModel>
{
    public int? Id { set; get; }
    public string? Exam { set; get; }
    public string? Type { set; get; }
    public string? Name { set; get; }

}

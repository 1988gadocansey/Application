namespace ApplicantPortal.Application.Common.Dtos;

using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;
public record FormerSchoolDto : IMapFrom<FormerSchoolModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }

}

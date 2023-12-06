using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;

namespace ApplicantPortal.Application.Common.Dtos;
public record RegionDto : IMapFrom<RegionModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }

}

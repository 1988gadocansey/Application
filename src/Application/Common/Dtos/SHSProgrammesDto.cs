using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;
namespace ApplicantPortal.Application.Common.Dtos;
public record SHSProgrammesDto : IMapFrom<SHSProgrammes>
{

    public int Id { set; get; }
    public string? Name { get; set; }


}

using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record DenominationDto : IMapFrom<DenominationModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }


}

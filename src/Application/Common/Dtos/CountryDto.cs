using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record CountryDto : IMapFrom<CountryModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }


}

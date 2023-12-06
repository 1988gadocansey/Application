using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record AddressDto : IMapFrom<AddressModel>
{

    public int Id { set; get; }
    public string? Street { set; get; }
    public string? HouseNumber { set; get; }
    public string? City { set; get; }
    public string? GPRS { set; get; }
    public string? Box { set; get; }

    public virtual ApplicantModel? Applicant { get; set; }

}

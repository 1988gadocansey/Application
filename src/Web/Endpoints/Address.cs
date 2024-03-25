using ApplicantPortal.Application.Address.Commands;
using ApplicantPortal.Application.Address.Queries;
using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Web.Endpoints;

public class Address : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(Index)
            .MapGet(Create);
    }
    private async Task<IEnumerable<AddressDto>> Index(ISender sender) => await sender.Send(new GetAddressQuery());

    private async Task<Guid> Create(ISender sender, CreateAddressRequest command) { return await sender.Send(command); }
}

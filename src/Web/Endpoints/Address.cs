
using ApplicantPortal.Application.Address.Commands;
using ApplicantPortal.Application.Address.Queries;
using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Web.Endpoints;

public class Address : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
           .MapGet(Addresses,"Addresses")
           .MapPost(Create,"Address/Create");
    }
   public async Task<PaginatedList<AddressDto>> Addresses(ISender sender) => await sender.Send(new GetAddressQuery());

   public async Task<int> Create(ISender sender, CreateAddressRequest command) { return await sender.Send(command); }
}


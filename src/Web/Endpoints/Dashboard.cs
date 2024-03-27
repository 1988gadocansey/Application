using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ApplicantPortal.Web.Endpoints;

public class Dashboard: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(Index);

    }
    public async Task<UserDto> Index(ISender sender) => await sender.Send(new GetUserQuery());
    

}

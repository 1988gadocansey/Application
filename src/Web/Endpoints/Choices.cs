using ApplicantPortal.Application.Choices.Queries;
using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Web.Endpoints;

public class Choices:EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(Choice,"Choices");

    }
    public async Task<ChoicesDto> Choice(ISender sender) => await sender.Send(new Choicequery());

}

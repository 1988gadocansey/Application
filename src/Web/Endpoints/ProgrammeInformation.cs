using ApplicantPortal.Application.ProgrammeInformation.Commands;
namespace ApplicantPortal.Web.Endpoints;

public class ProgrammeInformation: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            
            .MapPost(CreateProgrammes, "Info");
    }
 
    public async Task<int> CreateProgrammes(ISender sender, ProgrammeInfoRequest command) { return await sender.Send(command); }
  

}

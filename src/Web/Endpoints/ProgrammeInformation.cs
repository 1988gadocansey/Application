using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Application.ProgrammeInformation.Commands;
using ApplicantPortal.Application.ProgrammeInformation.Queries;

namespace ApplicantPortal.Web.Endpoints;

public class ProgrammeInformation: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetProgrammeInformation,"GetProgrammeInformation")
            .MapPost(CreateProgrammes, "Info");
    }
 
    public async Task<int> CreateProgrammes(ISender sender, ProgrammeInfoRequest command) { return await sender.Send(command); }
    public async Task<ApplicantVm> GetProgrammeInformation(ISender sender) => await sender.Send(new GetProgrammeInfoQuery());


}

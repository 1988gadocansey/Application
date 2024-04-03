using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.Referee.Commands;
using ApplicantPortal.Application.Referee.Queries;
using ApplicantPortal.Application.Results.Commands;
using ApplicantPortal.Application.UniversityAttended.Commands;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;

namespace ApplicantPortal.Web.Endpoints;

public class Referee : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetRefereeInfo, "GetRefereeInfo")
            .MapPost(CreateRefereeInfo, "Create")
            .MapDelete(DeleteRefereeInfo,"{id}");
    }
    
    public async Task<PaginatedList<RefereeDto>> GetRefereeInfo(ISender sender, [AsParameters] GetRefereeQuery query) { return await sender.Send(query); }
    public async Task<int> CreateRefereeInfo(ISender sender, CreateRefereeRequest command) { return await sender.Send(command); }
    public async Task<IResult> DeleteRefereeInfo(ISender sender, int id) { await sender.Send(new DeleteResultRequest(id)); return Results.NoContent();}

}

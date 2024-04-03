using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.PreviousSHSAttended.Queries;
using ApplicantPortal.Application.UniversityAttended.Commands;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;
namespace ApplicantPortal.Web.Endpoints;

 
public class EducationalBackground : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetEducationalBackgroundInfo, "GetEducationalBackgroundInfo")
            .MapPost(CreateEducationalBackgroundInfo, "CreateEducationalBackgroundInfo")
            .MapDelete(DeleteEducationalBackgroundInfo,"{id}");
    }
    
    public async Task<PaginatedList<SHSAttendedDto>> GetEducationalBackgroundInfo(ISender sender, [AsParameters] GetSHSAttendedQuery query) { return await sender.Send(query); }
    public async Task<int> CreateEducationalBackgroundInfo(ISender sender, SHSAttendedRequest command) { return await sender.Send(command); }
    public async Task<IResult> DeleteEducationalBackgroundInfo(ISender sender, int id) { await sender.Send(new DeleteUniversityAttendedRequest(id)); return Results.NoContent();}
    
}

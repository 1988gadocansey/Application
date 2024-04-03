using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.WorkingExperience.Commands;
using ApplicantPortal.Application.WorkingExperience.Queries;

namespace ApplicantPortal.Web.Endpoints;

public class WorkingExperience: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWorkingExperience, "GetWorkingExperience")
            .MapPost(CreateWorkingExperience, "CreateWorkingExperience")
            .MapDelete(DeleteWorkingExperience,"{id}");
    }
    
    public async Task<PaginatedList<WorkingExperienceDto>> GetWorkingExperience(ISender sender, [AsParameters] GetWorkingExperienceQuery query) { return await sender.Send(query); }
    public async Task<int> CreateWorkingExperience(ISender sender, WorkingExperienceRequest command) { return await sender.Send(command); }
    public async Task<IResult> DeleteWorkingExperience(ISender sender, int id) { await sender.Send(new DeleteWorkingExperienceRequest(id)); return Results.NoContent();}

}

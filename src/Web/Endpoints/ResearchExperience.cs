using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.ResearchExperience.Commands;
using ApplicantPortal.Application.ResearchExperience.Queries;
using OnlineApplicationSystem.Application.ResearchExperience.Commands;

namespace ApplicantPortal.Web.Endpoints;

public class ResearchExperience: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetResearchExperience, "GetResearchExperience")
            .MapPost(CreateResearchExperience, "CreateResearchExperience")
            .MapDelete(DeleteResearchExperience,"{id}");
    }
    
    public async Task<PaginatedList<ResearchExperienceDto>> GetResearchExperience(ISender sender, [AsParameters] GetResearchExperienceQuery query) { return await sender.Send(query); }
    public async Task<int> CreateResearchExperience(ISender sender, ResearchExperienceRequest command) { return await sender.Send(command); }
    public async Task<IResult> DeleteResearchExperience(ISender sender, int id) { await sender.Send(new DeleteResearchExperienceRequest(id)); return Results.NoContent();}

}

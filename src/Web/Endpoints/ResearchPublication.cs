using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.ResearchExperience.Commands;
using ApplicantPortal.Application.ResearchPublication.Commands;
using ApplicantPortal.Application.ResearchPublication.Queries;
using OnlineApplicationSystem.Application.ResearchExperience.Commands;

namespace ApplicantPortal.Web.Endpoints;

public class ResearchPublication: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetResearchPublication, "GetResearchPublication")
            .MapPost(CreateResearchPublication, "CreateResearchPublication")
            .MapDelete(DeleteResearchPublication,"{id}");
    }
    
    public async Task<PaginatedList<ResearchPublicationDto>> GetResearchPublication(ISender sender, [AsParameters] GetResearchPublicationQuery query) { return await sender.Send(query); }
    public async Task<int> CreateResearchPublication(ISender sender, ResearchPublicationRequest command) { return await sender.Send(command); }
    public async Task<IResult> DeleteResearchPublication(ISender sender, int id) { await sender.Send(new DeleteResearchPublicationRequest(id)); return Results.NoContent();}

    
}

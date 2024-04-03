using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.ResearchPublication.Commands;
using ApplicantPortal.Application.Results.Commands;
using ApplicantPortal.Application.Results.Queries;

namespace ApplicantPortal.Web.Endpoints;

public class ResultUpload: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUploadedResults, "GetUploadedResults")
            .MapPost(UploadResults, "UploadResults")
            .MapDelete(DeleteUploadResults,"{id}");
    }
    
    public async Task<PaginatedList<ResultsDto>> GetUploadedResults(ISender sender, [AsParameters] GetResultQuery query) { return await sender.Send(query); }
    public async Task<int> UploadResults(ISender sender, CreateResultRequest command) { return await sender.Send(command); }
    public async Task<IResult> DeleteUploadResults(ISender sender, int id) { await sender.Send(new DeleteResultRequest(id)); return Results.NoContent();}

}

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;
using ApplicantPortal.Application.DocumentUpload.Commands;
using ApplicantPortal.Application.DocumentUpload.Queries;

namespace ApplicantPortal.Web.Endpoints;

public class DocumentUpload : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUploadedDocuments, "GetUploadedDocuments")
            .MapPost(CreateUploadedDocuments, "CreateUploadedDocuments");
    }
    
    public async Task<PaginatedList<DocumentUploadDto>> GetUploadedDocuments(ISender sender, [AsParameters] GetDocumentUploadQuery query) { return await sender.Send(query); }
    public async Task<int> CreateUploadedDocuments(ISender sender, UploadDocumentRequest command) { return await sender.Send(command); }
}

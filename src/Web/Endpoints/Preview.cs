using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Application.Preview;
using ApplicantPortal.Application.Preview.Commands;
using ApplicantPortal.Application.SelectBoxItems;

namespace ApplicantPortal.Web.Endpoints;


public class Preview : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(PreviewForm, "PreviewForm")
            .MapGet(PreviewUniversity, "PreviewUniversity")
            .MapGet(PreviewShs, "PreviewShs")
            .MapGet(GetProgrammeById, "GetProgrammeById/{id}")
            .MapPost(Finalized, "Finalized");
    }
    public async Task<ApplicantVm> PreviewForm(ISender sender) => await sender.Send(new GetApplicantQuery());
    public async Task<int> Finalized(ISender sender, FinalizedRequest command) { return await sender.Send(command); }
    public async Task<UniversityAttendedDto> PreviewUniversity(ISender sender) => await sender.Send(new GetSingleUniversityAttendedQuery());
    public async Task<SHSAttendedDto> PreviewShs(ISender sender) => await sender.Send(new GetSingleSHSQuery());
    public async Task<ProgrammeDto> GetProgrammeById(ISender sender,int id) => await sender.Send(new GetProgrammeByIdQuery());
    
}
    

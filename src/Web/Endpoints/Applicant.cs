using ApplicantPortal.Application.Common.ViewModels;
using ApplicantPortal.Application.FormCategories.Commands;
using ApplicantPortal.Application.FormCategories.Queries;
using ApplicantPortal.Application.Preview;
using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Web.Endpoints;

public class Applicant : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(Index,"Index")
           .MapGet(GetForms,"Forms/Change")
            .MapPost(SaveFormChanges,"Forms/Change");
    }

    public async Task<ApplicantVm> Index(ISender sender) => await sender.Send(new GetApplicantQuery());
    public async Task<IEnumerable<ApplicationType>> GetForms(ISender sender) => await sender.Send(new GetFormsQuery());
    public async Task<bool> SaveFormChanges(ISender sender, CreateFormUpdateRequest command) { return await sender.Send(command); }
}

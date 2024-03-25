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
            .MapGet(Index)
            .MapGet(GetForms)
            .MapPost(SaveFormChanges);
    }
    private async Task<ApplicantVm> Index(ISender sender) => await sender.Send(new GetApplicantQuery());
    private async  Task<IEnumerable<ApplicationType>> GetForms(ISender sender) => await sender.Send(new GetFormsQuery());
    private async Task<bool> SaveFormChanges(ISender sender, CreateFormUpdateRequest command) { return await sender.Send(command); }
}

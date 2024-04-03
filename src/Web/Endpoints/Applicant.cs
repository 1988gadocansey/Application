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
            .MapGet(ApplicantInfo,"ApplicantInfo")
            .MapGet(GetForm,"GetForm")
            .MapPost(SaveFormChanges,"Save");
    }

    public async Task<ApplicantVm> ApplicantInfo(ISender sender) => await sender.Send(new GetApplicantQuery());
    public async Task<IEnumerable<ApplicationType>> GetForm(ISender sender) => await sender.Send(new GetFormsQuery());
    public async Task<bool> SaveFormChanges(ISender sender, CreateFormUpdateRequest command) { return await sender.Send(command); }
}

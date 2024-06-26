
using ApplicantPortal.Application.Address.Commands;
using ApplicantPortal.Application.Address.Queries;
using ApplicantPortal.Application.Biodata.Commands.CreateBiodata;
using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Web.Endpoints;

public class Biodata : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateBiodata,"Create");
    }

    public async Task<int> CreateBiodata(ISender sender, CreateBiodataRequest command)
    {
        Console.WriteLine($"the firstname is .... {command.FirstName}");
        return await sender.Send(command);
    }
}


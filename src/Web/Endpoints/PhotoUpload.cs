using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.PhotoUpload.Commands;
using ApplicantPortal.Application.User.Queries;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApplicantPortal.Web.Endpoints;

public class PhotoUpload : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(UploadImages);
    }

    public async Task<int> UploadImages(IEnumerable<IFormFile> formFiles, ISender sender, UploadPictureRequest command)
    {
        foreach (var formFile in formFiles)
        {
            if (formFile.Length <= 250000)
            {
                var file = new FileDto
                {
                    Content = formFile.OpenReadStream(),
                    Name = formFile.FileName,
                    UserId = null,
                    ContentType = formFile.ContentType,
                };
                command.Files.Add(file);
            }
            else
            {
                return await sender.Send(command);
            }
        }
        
        return await sender.Send(command);
    }
}

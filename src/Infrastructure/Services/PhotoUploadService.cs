using System.Net.Mime;
using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Renci.SshNet;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ApplicantPortal.Infrastructure.Services;

public class PhotoUploadService(
    IConfiguration configuration,
    IWebHostEnvironment hostingEnvironment,
    UserManager<ApplicationUser> userManager) : IPhotoUploadService
{
    public async Task<int> SendFileToServer(string applicant, IEnumerable<FileDto> files,
        CancellationToken cancellationToken)
    {
        var userdetails = await userManager.Users.Select(b =>
            new UserDto()
            {
                Id = b.Id,
                UserName = b.UserName,
                FormCompleted = b.FormCompleted,
                Finalized = b.Finalized,
                SoldBy = b.SoldBy,
                Started = b.Started,
                Year = b.Year,
                PictureUploaded = b.PictureUploaded,
                FormNo = b.FormNo,
                FullName = b.FullName,
                ResultUploaded = b.ResultUploaded,
                Admitted = b.Admitted,
                LastLogin = b.LastLogin,
                Type = b.VoucherType
            }).FirstOrDefaultAsync(a => a.Id == applicant, cancellationToken: cancellationToken);

        var applicationNo = userdetails?.FormNo;
        foreach (var formFile in files)
        {
            var fileName = formFile.Name;
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "pictures");
            var extension = Path.GetExtension(fileName)!.ToLower();
            var pictureToSave = applicationNo + extension;
            var fileLocation = Path.Combine(uploads, pictureToSave);
            var port = Convert.ToInt32(configuration["sftpport"]);
            var host = configuration["sftphost"];
            var username = configuration["sftpusername"];
            var password = configuration["sftppassword"];
            var image = await Image.LoadAsync(formFile.Content!, cancellationToken);
            image.Mutate(img => img.AutoOrient());
            image.Mutate(x => x.Resize(413, 531));
            try
            {
                 await image.SaveAsync(fileLocation, cancellationToken);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine("Exception generated when uploading file - " + exp.Message);

                return await Task.FromResult(0);
            }

            using var client = new SftpClient(host, port, username, password);
            await client.ConnectAsync(cancellationToken);
            if (client.IsConnected)
            {
                Console.WriteLine("I'm connected to the client");
                client.ChangeDirectory("/var/www/html/photos/public/albums/thumbnails");
                await using var fileStream = new FileStream(fileLocation, FileMode.Open);
                client.BufferSize = 4 * 1024; // bypass Payload error large files
                client.UploadFile(fileStream, Path.GetFileName(fileLocation));
            }

            var fileInfo = new FileInfo(fileLocation);
            fileInfo.Delete();

            return await Task.FromResult(1);
        }

        // now lets create an issue for picture upload
        Console.WriteLine("I couldn't connect");
        return await Task.FromResult(0);
    }

    string IPhotoUploadService.UserId
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public Task<UrlsDto> UploadAsync(ICollection<FileDto>? files)
    {
        if (files == null || files.Count == 0)
        {
            return Task.FromResult<UrlsDto>(null!);
        }

        //var containerClient = _blobServiceClient.GetBlobContainerClient("publicuploads");


        var urls = new List<string>();


        /* foreach (var file in files)
        {
            var blobClient = containerClient.GetBlobClient(file.GetPathWithFileName());

            await blobClient.UploadAsync(file.Content, new BlobHttpHeaders { ContentType = file.ContentType });

            urls.Add(blobClient.Uri.ToString());
        } */
        return Task.FromResult(new UrlsDto(urls));
    }
}

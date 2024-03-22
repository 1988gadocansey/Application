using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Renci.SshNet;
using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Infrastructure.Services
{
    public class DocumentUploadService(
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment,
        IApplicantRepository applicantRepository)
        : IDocumentUploadService
    {
        private Task<SftpClient> GetSftpClientAsync()
        {
            var sftpClient = new SftpClient(
                configuration["sftphost"],
                int.Parse(configuration["sftpport"]!),
                configuration["sftpusername"],
                configuration["sftppassword"]);

            sftpClient.Connect();
            if (!sftpClient.IsConnected)
            {
                throw new InvalidOperationException("Failed to connect to SFTP server.");
            }

            return Task.FromResult(sftpClient);
        }

        //public string? UserId { get; set; }

        public string? UserId   { get; set; }

        public async Task<int> UploadFiles(long applicantId, IEnumerable<FileDto> files, CancellationToken cancellationToken)
        {
            var user = await applicantRepository.GetApplicantByApplicationNumber(applicantId, cancellationToken);

            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var applicationNo = user.ApplicationNumber;
            var uploadsPath = Path.Combine(hostingEnvironment.WebRootPath, "pictures");

            foreach (var formFile in files)
            {
                var fileName = formFile.Name;
                var extension = Path.GetExtension(fileName)!.ToLower();
                var pictureToSave = $"{applicationNo}{extension}";
                var fileLocation = Path.Combine(uploadsPath, pictureToSave);

                try
                {
                    await using (var stream = new FileStream(fileLocation, FileMode.Create))
                    {
                        await formFile.Content!.CopyToAsync(stream, cancellationToken);
                    }

                    using var sftpClient = await GetSftpClientAsync();
                    sftpClient.ChangeDirectory("/var/www/html/documents/admissions/postgraduates");

                    await using (var fileStream = new FileStream(fileLocation, FileMode.Open))
                    {
                        sftpClient.BufferSize = 4 * 1024;
                        sftpClient.UploadFile(fileStream, Path.GetFileName(fileLocation));
                    }

                    File.Delete(fileLocation); // Delete local file after upload

                    return 1; // Success
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception while uploading file: {ex.Message}");
                    return 0; // Failure
                }
            }

            Console.WriteLine("No files to upload.");
            return 0; // No files to upload
        }

        public Task<byte[]?> DownloadFiles(long applicant, string basePath, string fileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFile(long applicant, string file, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UploadFileToServerAsync(Stream stream, string basePath, string fileName, bool overwrite = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Sftp(string server, int port, bool passive, string username, string password, string filename, int counter,
            byte[] contents, out string error, bool rename)
        {
            throw new NotImplementedException();
        }

        // Other methods omitted for brevity
    }
}

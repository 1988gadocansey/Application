using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Application.Common.Interfaces;


public interface IDocumentUploadService
{
    string UserId { get; set; }
    Task<int> UploadFiles(long applicant, IEnumerable<FileDto> files, CancellationToken cancellationToken);

    Task<byte[]?> DownloadFiles(long applicant, string basePath, string fileName, CancellationToken cancellationToken);
    Task<bool> DeleteFile(long applicant, string file, CancellationToken cancellationToken);

    // the following methods are trials
    Task UploadFileToServerAsync(Stream stream, string basePath, string fileName, bool overwrite = false);
    Task<bool> Sftp(string server, int port, bool passive, string username, string password, string filename, int counter, byte[] contents, out string error, bool rename);


}

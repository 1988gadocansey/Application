using ApplicantPortal.Application.Common.Dtos;
namespace ApplicantPortal.Application.Common.Interfaces;
public interface IPhotoUploadService
{
    string UserId { get; set; }
    Task<UrlsDto> UploadAsync(ICollection<FileDto>? files);
    Task<int> SendFileToServer(string applicant, IEnumerable<FileDto> files, CancellationToken cancellationToken);

}

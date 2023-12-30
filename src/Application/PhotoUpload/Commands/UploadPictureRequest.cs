using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Application.PhotoUpload.Commands;

public record UploadPictureRequest : IRequest<int>
{
    public string? UserId { get; init; }
    public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
}

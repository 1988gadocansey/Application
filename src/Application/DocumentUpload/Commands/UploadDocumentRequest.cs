using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Application.DocumentUpload.Commands;

public class UploadDocumentRequest : IRequest<int>
{
    public string? UserId { get; init; }
    public int Id { get; set; }
    public int Applicant { set; get; }
    public string? Name { set; get; }
    public string? Type { set; get; }
    public IEnumerable<FileDto> Files { get; set; } = new List<FileDto>();
}

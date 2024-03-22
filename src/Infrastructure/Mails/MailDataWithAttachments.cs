


using Microsoft.AspNetCore.Http;

namespace ApplicantPortal.Infrastructure.Mails;

public class EmailMessage
{
    public string? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public List<Attachment> Attachments { get; set; } = [];
}

public class Attachment
{
    public string? FileName { get; set; }
    public byte[]? FileData { get; set; }
}

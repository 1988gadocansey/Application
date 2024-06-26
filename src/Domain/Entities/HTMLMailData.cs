namespace ApplicantPortal.Domain.Entities;

public record HtmlMailData(string EmailToId, string EmailToName)
{
    public string EmailToId { get; set; } = EmailToId;
    public string EmailToName { get; set; } = EmailToName;
}

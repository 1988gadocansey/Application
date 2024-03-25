namespace ApplicantPortal.Domain.Entities;
public class MailData(string emailToId, string emailToName, string emailSubject, string emailBody)
{
    public string EmailToId { get; set; } = emailToId;
    public string EmailToName { get; set; } = emailToName;
    public string EmailSubject { get; set; } = emailSubject;
    public string EmailBody { get; set; } = emailBody;
}

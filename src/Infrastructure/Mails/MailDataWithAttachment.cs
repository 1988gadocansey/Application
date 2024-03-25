using ApplicantPortal.Domain.Entities;
using Microsoft.AspNetCore.Http;
namespace ApplicantPortal.Infrastructure.Mails;

public class MailDataWithAttachment(string emailToId, string emailToName, string emailSubject, string emailBody) : MailData(emailToId, emailToName, emailSubject, emailBody)
{
    public IFormFileCollection? EmailAttachments { get; set; }
}

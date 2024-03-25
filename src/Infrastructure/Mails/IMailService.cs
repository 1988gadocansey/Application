using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Infrastructure.Mails;

public interface IMailService
{
    Task<bool> SendMail(MailData mailData);
    Task<bool> SendHtmlMail(HtmlMailData htmlMailData);
   Task<bool> SendMailWithAttachment(MailDataWithAttachment mailData);

}

using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Interfaces;

public interface IEmailSender
{
    Task SendEmail(string? to, string? subject, string? body, string? From);
    Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    // Task<bool> SendWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken ct);
    //string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel);
}

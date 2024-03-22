using System.Net.Mail;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ApplicantPortal.Infrastructure.Mails;

public class EmailService :IEmailSender
{
  
    public async Task SendEmailAsync(EmailMessage message)
    {
        // Implement your email sending logic here

        Console.WriteLine($"Sending email to {message.To}: {message.Subject}");
        Console.WriteLine($"Body: {message.Body}");

        // Simulate sending email
        await Task.Delay(1000);

        // Process attachments if any
        if (message.Attachments != null && message.Attachments.Any())
        {
            foreach (var attachment in message.Attachments)
            {
                // Save attachment logic (e.g., save to disk, upload to cloud storage, etc.)
                Console.WriteLine($"Attachment: {attachment.FileName}");
                // Here you can handle saving/uploading the attachment data
            }
        }
    }


    public Task SendEmail(string? to, string? subject, string? body, string? From)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SendAsync(MailData mailData, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}

 

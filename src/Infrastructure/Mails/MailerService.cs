using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ApplicantPortal.Infrastructure.Mails;

public class MailSettings
{
    public static string? Server;
    public static int Port;
    public static string? SenderName;
    public static  string? SenderEmail;
    public static  string? UserName;
    public static string? Password;

    
}
public class MailerService(
 
    IApplicantRepository applicantRepository,
    IConfiguration configuration)
    : IEmailSender
{
    private readonly IApplicantRepository _applicantRepository = applicantRepository;
    private readonly IConfiguration _configuration = configuration;

    public async Task SendEmail(string? to, string? subject, string? body, string? From)
    {
        var email = new MimeMessage();
        email.Sender = new MailboxAddress("TTU Admissions", "gadocansey@gmail.com");
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        var builder = new BodyBuilder { HtmlBody = body };
        using var smtp = new SmtpClient();
        email.Body = builder.ToMessageBody();
        await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync("gadocansey@gmail.com", "jzpgrzmrnwkbknkd");
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task<bool> SendAsync(MailData mailData, CancellationToken ct)
    {
        try
        {
            using MimeMessage emailMessage = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress(MailSettings.SenderName, MailSettings.SenderEmail);
            emailMessage.From.Add(emailFrom);
            MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
            emailMessage.To.Add(emailTo);

            // you can add the CCs and BCCs here.
            //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
            //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

            emailMessage.Subject = mailData.EmailSubject;

            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.TextBody = mailData.EmailBody;

            emailMessage.Body = emailBodyBuilder.ToMessageBody();
            //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
            using SmtpClient mailClient = new SmtpClient();
          
            await mailClient.ConnectAsync(MailSettings.Server, MailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await mailClient.AuthenticateAsync(MailSettings.UserName, MailSettings.Password);
            await mailClient.SendAsync(emailMessage);
            await mailClient.DisconnectAsync(true);


            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return await Task.FromResult(true);
        }
    }
     public async Task<bool> SendHtmlMail(HtmlMailData htmlMailData)
    {
        try
        {
            using MimeMessage emailMessage = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress(MailSettings.SenderName, MailSettings.SenderEmail);
            emailMessage.From.Add(emailFrom);

            MailboxAddress emailTo = new MailboxAddress(htmlMailData.EmailToName, htmlMailData.EmailToId);
            emailMessage.To.Add(emailTo);

            emailMessage.Subject = "Hello";

            string filePath = Directory.GetCurrentDirectory() + "\\Templates\\Hello.html";
            string emailTemplateText = File.ReadAllText(filePath);

            emailTemplateText = string.Format(emailTemplateText, htmlMailData.EmailToName, DateTime.Today.Date.ToShortDateString());

            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.HtmlBody = emailTemplateText;
            emailBodyBuilder.TextBody = "Plain Text goes here to avoid marked as spam for some email servers.";

            emailMessage.Body = emailBodyBuilder.ToMessageBody();

            using SmtpClient mailClient = new SmtpClient();
            mailClient.Connect(MailSettings.Server, MailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            mailClient.Authenticate(MailSettings.SenderEmail, MailSettings.Password);
            mailClient.Send(emailMessage);
            mailClient.Disconnect(true);

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return await Task.FromResult(false);
        }
    }
      public async Task<bool> SendMailWithAttachment(MailDataWithAttachment mailData)
    {
        try
        {
            using (MimeMessage emailMessage = new MimeMessage())
            {
                MailboxAddress emailFrom = new MailboxAddress(MailSettings.SenderName, MailSettings.SenderEmail);
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                emailMessage.To.Add(emailTo);

                // you can add the CCs and BCCs here.
                //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                emailMessage.Subject = mailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = mailData.EmailBody;

                if (mailData.EmailAttachments != null)
                {
                    foreach (var attachmentFile in mailData.EmailAttachments!)
                    {
                        if (attachmentFile.Length == 0)
                        {
                            continue;
                        }

                        using MemoryStream memoryStream = new MemoryStream();
                        attachmentFile.CopyTo(memoryStream);
                        var attachmentFileByteArray = memoryStream.ToArray();

                        emailBodyBuilder.Attachments.Add(attachmentFile.FileName, attachmentFileByteArray, ContentType.Parse(attachmentFile.ContentType));
                    }
                }

                emailMessage.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                using (SmtpClient mailClient = new SmtpClient())
                {
                    await mailClient.ConnectAsync(MailSettings.Server, MailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                    await mailClient.AuthenticateAsync(MailSettings.UserName, MailSettings.Password);
                    await mailClient.SendAsync(emailMessage);
                    await mailClient.DisconnectAsync(true);
                }
            }

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return await Task.FromResult(false);
        }
    }
}

namespace ApplicantPortal.Infrastructure.Mails;

public class MailSettings(
    string server,
    int port,
    string senderName,
    string senderEmail,
    string userName,
    string password)
{
    public string Server { get; set; } = server;
    public int Port { get; set; } = port;
    public string SenderName { get; set; } = senderName;
    public string SenderEmail { get; set; } = senderEmail;
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
}

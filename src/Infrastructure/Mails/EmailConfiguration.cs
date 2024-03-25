namespace ApplicantPortal.Infrastructure.Mails;

public class EmailConfiguration(string from, string smtpServer, int port, string userName, string password)
{
    public string From { get; set; } = from;
    public string SmtpServer { get; set; } = smtpServer;
    public int Port { get; set; } = port;
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
}

namespace ApplicantPortal.Application.Common.Interfaces;

public interface ISmsSender
{
    Task SendSms(string phoneNumber, string message, long formNo, string appSender, CancellationToken cancellationToken);
}

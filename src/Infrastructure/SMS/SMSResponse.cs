namespace ApplicantPortal.Infrastructure.SMS;

public class SMSResponse
{
    public decimal? rate { get; set; }
    public Guid? messageId { get; set; }
    public int? status { get; set; }
    public string? networkId { get; set; }
}

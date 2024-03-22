/*
namespace ApplicantPortal.Web.Endpoints;

public class Finalize : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public EmailController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailMessage email)
    {
        // Add attachments if needed
        email.Attachments.Add(new Attachment { FileName = "attachment.txt", FileData = Encoding.UTF8.GetBytes("Attachment data") });

        // Enqueue the email message
        await _emailSender.SendEmailAsync(email);
        return Ok("Email sent successfully.");
    }
}
*/

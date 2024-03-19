namespace OnlineApplicationSystem.Application.Preview.Commands;
public record EmailRequest
{
    public string? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? From { get; set; }
}
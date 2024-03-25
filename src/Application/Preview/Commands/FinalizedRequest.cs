namespace ApplicantPortal.Application.Preview.Commands;

public record FinalizedRequest : IRequest<int>
{
    public string? Id { get; set; }
}

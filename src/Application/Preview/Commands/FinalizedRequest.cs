namespace ApplicantPortal.Application.Preview.Commands;

public class FinalizedRequest : IRequest<int>
{
    public string? Id { get; set; }
}

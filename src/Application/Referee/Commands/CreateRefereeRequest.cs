namespace ApplicantPortal.Application.Referee.Commands;

public record CreateRefereeRequest : IRequest<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Institution { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public int? ApplicantModel { get; set; }
}

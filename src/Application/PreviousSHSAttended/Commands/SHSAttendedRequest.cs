using MediatR;

namespace OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;

public record SHSAttendedRequest : IRequest<int>
{

    public int? NameId { set; get; }
    public string? ProgrammeStudied { get; set; }

    public int? Region { set; get; }
    public int? Applicant { set; get; }
    public int? StartYear { set; get; }
    public int? EndYear { set; get; }


}
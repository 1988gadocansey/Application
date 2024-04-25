using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Choices.Commands;

public record ChoiceRequest : IRequest<int>
{
    public ProgrammeModel? FirstChoice { set; get; }
    public ProgrammeModel? SecondChoice { set; get; }
    public ProgrammeModel? ThirdChoice { set; get; }
}

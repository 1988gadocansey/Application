using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Application.ProgrammeInformation.Commands;
public record ProgrammeInfoRequest : IRequest<int>
{

    public string? Id { get; init; }

    public Session? EntryMode { get; init; }
    public EntryQualification? FirstQualification { get; init; }
    public EntryQualification? SecondQualification { get; init; }
    public int? FirstChoiceId { get; init; }
    public int? SecondChoiceId { get; init; }
    public int? ThirdChoiceId { get; init; }
    public bool? Awaiting { get; init; }
    public int? LastYearInSchool { get; init; }
    public string? IndexNo { get; init; }


}

using ApplicantPortal.Application.Common.Dtos;

namespace ApplicantPortal.Application.SelectBoxItems;


public abstract record GetLanguageQuery : IRequest<IEnumerable<LanguageDto>>;

public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, IEnumerable<LanguageDto>>
{
    private static readonly string[] Summaries = new[]
    {
        "GA-DANGME", "EWE", "AKAN", "DAGAARE", "DAGBANE", "NZEMA", "KASEM", "GONJA", "HAUSA"
    };

    public Task<IEnumerable<LanguageDto>> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Summaries.Select(summary => new LanguageDto { Name = summary }));
    }
}

namespace ApplicantPortal.Application.SelectBoxItems;
public abstract record DisabilityChoiceQuery : IRequest<IEnumerable<string>>;

public class DisabilityChoiceQueryHandler : IRequestHandler<DisabilityChoiceQuery, IEnumerable<string>>
{
    public async Task<IEnumerable<string>> Handle(DisabilityChoiceQuery request, CancellationToken cancellationToken)
    {
        var Disabilities = new[]
        {
            "DEAF", "DUMB", "DEAF and DUMB", "BLIND (1 Eye)", "DEAF (1 Ear)", "CRIPPLED", "AMPUTEE", "BLIND"
        };
        return await Task.FromResult(Disabilities);
    }
}


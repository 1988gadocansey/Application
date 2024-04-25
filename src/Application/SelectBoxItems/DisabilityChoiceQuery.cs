namespace ApplicantPortal.Application.SelectBoxItems;
public   record DisabilityChoiceQuery : IRequest<IEnumerable<string>>;

public class DisabilityChoiceQueryHandler : IRequestHandler<DisabilityChoiceQuery, IEnumerable<string>>
{
    public async Task<IEnumerable<string>> Handle(DisabilityChoiceQuery request, CancellationToken cancellationToken)
    {
        var Disabilities = new[]
        {
            "Deaf", "Hearing Impaired", "Wheelchair Bound", "Lame (In Crutches)", "Physically Handicapped", "Blind", "Speech Impaired", "Speech Impaired","Partially Sighted","Other"
        };
        return await Task.FromResult(Disabilities);
    }
}


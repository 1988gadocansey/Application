using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Application.FormCategories.Queries;

public record GetFormsQuery : IRequest<IEnumerable<ApplicationType>>;

public class GetFormsQueryHandler : IRequestHandler<GetFormsQuery, IEnumerable<ApplicationType>>
{
    public Task<IEnumerable<ApplicationType>> Handle(GetFormsQuery request, CancellationToken cancellationToken)
    {
        var formTypes = Enum.GetValues<ApplicationType>();
        return Task.FromResult<IEnumerable<ApplicationType>>(formTypes);
    }

}

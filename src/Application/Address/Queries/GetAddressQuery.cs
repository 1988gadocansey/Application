using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Address.Queries;
public abstract record GetAddressQuery : IRequest<IEnumerable<AddressDto>>;

public class GetAddressQueryHandler(IUser currentUserService, IApplicantRepository applicantRepository): IRequestHandler<GetAddressQuery, IEnumerable<AddressDto>>
{
    public async Task<IEnumerable<AddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {

        var applicantDetails = await applicantRepository.GetApplicantForUser(currentUserService.Id, cancellationToken);

        return await applicantRepository.GetAddresses(applicantDetails.Id, cancellationToken);

    }
}

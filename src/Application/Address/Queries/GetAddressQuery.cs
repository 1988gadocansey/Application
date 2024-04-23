using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.Address.Queries;

//public  record GetAddressQuery : IRequest<IEnumerable<AddressDto>>;
public record GetAddressQuery : IRequest<PaginatedList<AddressDto>>
{
    public int Id { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAddressQueryHandler(IApplicationDbContext context, IMapper mapper, IUser currentUserService)
    : IRequestHandler<GetAddressQuery, PaginatedList<AddressDto>>
{
    public async Task<PaginatedList<AddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var applicant = await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId, cancellationToken: cancellationToken);
        return await context.AddressModels
            .Where(x => x.Applicant!.Id == applicant!.Id)
            .OrderBy(x => x.City)
            .ProjectTo<AddressDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Address.Commands;
public  record DeleteAddressRequest(int Id) : IRequest;
public class DeleteAddressCommand(IApplicationDbContext context) : IRequestHandler<DeleteAddressRequest>
{
    public async Task Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.AddressModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(AddressModel), request.Id.ToString());
        }

        context.AddressModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

        
    }
}

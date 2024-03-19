using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.PreviousSHSAttended.Commands;
public record DeleteSHSAttendedRequest(int Id) : IRequest;
public class DeleteSHSAttendedCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteSHSAttendedRequest>
{
    public async Task Handle(DeleteSHSAttendedRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.ShsAttendedModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id.ToString());
        }

        context.ShsAttendedModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

        
    }
}

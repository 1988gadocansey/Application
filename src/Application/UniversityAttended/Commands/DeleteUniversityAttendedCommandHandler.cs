using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.UniversityAttended.Commands;
public   record DeleteUniversityAttendedRequest(int Id) : IRequest;

public class DeleteUniversityAttendedCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteUniversityAttendedRequest>
{
    public async Task Handle(DeleteUniversityAttendedRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.UniversityAttendedModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UniversityAttended), request.Id.ToString());
        }
        context.UniversityAttendedModels.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        
    }
}

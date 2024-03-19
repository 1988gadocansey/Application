using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Results.Commands;

public record DeleteResultRequest(int Id) : IRequest;

public class DeleteResultCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteResultRequest>
{
    public async Task Handle(DeleteResultRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.ResultUploadModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id.ToString());
        }

        context.ResultUploadModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

        
    }
}

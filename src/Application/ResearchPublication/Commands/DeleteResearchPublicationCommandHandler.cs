using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.ResearchPublication.Commands;

public   record DeleteResearchPublicationRequest(int Id) : IRequest;

public class DeleteResearchPublicationCommand(IApplicationDbContext context)
    : IRequestHandler<DeleteResearchPublicationRequest>
{
    public async Task Handle(DeleteResearchPublicationRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.ResearchPublicationModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id.ToString());
        }

        context.ResearchPublicationModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);
    }
}

using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.ResearchExperience.Commands;
public    record DeleteResearchExperienceRequest(int Id) : IRequest;

public class DeleteResearchExperienceCommand(IApplicationDbContext context)
    : IRequestHandler<DeleteResearchExperienceRequest>
{
    public async Task Handle(DeleteResearchExperienceRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.ResearchModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id.ToString());
        }

        context.ResearchModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);
 
    }
}

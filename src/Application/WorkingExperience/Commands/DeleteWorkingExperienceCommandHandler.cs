using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.WorkingExperience.Commands;
public record DeleteWorkingExperienceRequest(int Id) : IRequest;

public class DeleteWorkingExperienceCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteWorkingExperienceRequest>
{
    public async Task Handle(DeleteWorkingExperienceRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.WorkingExperienceModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(WorkingExperience), request.Id.ToString());
        }

        context.WorkingExperienceModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

         
    }
}

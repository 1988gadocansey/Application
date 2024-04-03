using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Referee.Commands;
public  record DeleteRefereeRequest(int Id) : IRequest;

public class DeleteRefereeCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteRefereeRequest>
{
    public async Task Handle(DeleteRefereeRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.RefereeModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id.ToString());
        }

        context.RefereeModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

        
    }
}

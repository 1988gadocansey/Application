using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.DocumentUpload.Commands;

public    record DeleteDocumentUploadRequest(int Id) : IRequest;

public class DeleteDocumentUploadCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteDocumentUploadRequest>
{
    public async Task Handle(DeleteDocumentUploadRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.DocumentUploadModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(DocumentUploadModel), request.Id.ToString());
        }

        context.DocumentUploadModels.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

        // lets delete the files
        // use file interface to delete those files
         
    }
}

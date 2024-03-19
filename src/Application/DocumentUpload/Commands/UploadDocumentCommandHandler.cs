using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.DocumentUpload.Commands;


public class UploadDocumentCommandHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    IApplicantRepository applicantRepository,
    IIdentityService identityService,
    IDocumentUploadService documentUploadService,
    IMapper mapper)
    : IRequestHandler<UploadDocumentRequest, int>
{
    public async Task<int> Handle(UploadDocumentRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await applicantRepository.GetApplicantForUser(userId, cancellationToken);
        var pictureUpload = await documentUploadService.UploadFiles(Convert.ToInt64(applicantDetails.ApplicationNumber), request.Files, cancellationToken);
        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id.ToString()); ;
        var documentDetails = new DocumentUploadDto
        {
            Id = request.Id,
            Type = request.Type,
            Name = request.Name,
            Applicant = applicantDetails.Id
        };

        var dataMapped = mapper.Map<DocumentUploadModel>(documentDetails);
        await context.DocumentUploadModels.AddAsync(dataMapped, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await documentUploadService.DeleteFile(Convert.ToInt64(applicantDetails.ApplicationNumber), request.Name!, cancellationToken);
        return documentDetails.Id;

    }
}

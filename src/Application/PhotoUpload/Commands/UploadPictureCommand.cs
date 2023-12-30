using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.PhotoUpload.Commands;

public class UploadPictureCommand(
    IUser currentUserService,
    IApplicationDbContext context,
    IIdentityService identityService,
    IPhotoUploadService photoUploadService) : IRequestHandler<UploadPictureRequest, int>
{
    public async Task<int> Handle(UploadPictureRequest request, CancellationToken cancellationToken)
    {
        var pictureUpload =
            await photoUploadService.SendFileToServer(currentUserService.Id!, request.Files, cancellationToken);
        await identityService.UpdateApplicationPictureStatus(currentUserService.Id, request.Files, cancellationToken);
        //lets create issue flag here
        var applicant =
            await context.ProgressModels.FirstOrDefaultAsync(u => u.ApplicationUserId == currentUserService.Id,
                cancellationToken);

        if (applicant == null)
        {
            var issueFlag = (pictureUpload == 1);
            var issue = new ProgressModel { Picture = issueFlag, ApplicationUserId = currentUserService.Id };
            context.ProgressModels.Add(issue);
            await context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            applicant.Picture = (pictureUpload == 1);
            await context.SaveChangesAsync(cancellationToken);
        }

        return pictureUpload;
    }
}

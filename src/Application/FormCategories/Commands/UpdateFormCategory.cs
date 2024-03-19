using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.FormCategories.Commands;

public class UpdateFormCategory( IUser currentUser,  IIdentityService identityService) : IRequestHandler<CreateFormUpdateRequest, bool>
{
    public async Task<bool> Handle(CreateFormUpdateRequest request, CancellationToken cancellationToken) { return await identityService.ChangeApplicantFormType(currentUser.Id, request.FormType.ToString()); }
}

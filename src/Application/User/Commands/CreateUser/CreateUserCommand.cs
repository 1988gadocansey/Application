using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.User.Commands.CreateUser;

public class CreateUserCommand(IIdentityService identityService) : IRequestHandler<CreateUserRequest>
{
    public async Task  Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await identityService.GenerateVoucher(request.Quantity, request.Type, request.Owner, cancellationToken);
    }
   // Important Note : if you method is not async, the return is
      //  return Task.CompletedTask
}

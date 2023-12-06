using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Security;
namespace ApplicantPortal.Application.User.Queries;

[Authorize]
public record GetUserQuery : IRequest<UserDto>;
public class GetUserQueryHandler( IUser currentUserService, IIdentityService identityService) : IRequestHandler<GetUserQuery, UserDto>
{ 
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken) => await identityService.GetApplicationUserDetails(currentUserService.Id, cancellationToken);

}

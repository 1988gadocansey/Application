using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Models;

namespace ApplicantPortal.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
    Task<UserDto> GetApplicationUserDetails(string? userId, CancellationToken cancellationToken);

    Task<Result> GenerateVoucher(int? quantity, ApplicationType type, string? owner,
        CancellationToken cancellationToken);

    Task UpdateApplicationPictureStatus(string? userId, ICollection<FileDto> photo,
        CancellationToken cancellationToken);

    Task<bool> ChangeApplicantFormType(string? userId, string? formType);
    Task<string> Shuffle(string str);
    Task<string> GetSerial();
    Task<string> GetPin();

    Task<Result> GenerateVoucher(int? quantity, string? type, string? owner, CancellationToken cancellationToken);
    public Task Finalized(string userId);
}

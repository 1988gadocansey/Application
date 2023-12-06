using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.User.Commands.CreateUser;

 public record CreateUserRequest : IRequest 
{
    public ApplicationType Type { get; set; }
    public string? Owner { get; set; }
    public int? Quantity { get; set; } 
}

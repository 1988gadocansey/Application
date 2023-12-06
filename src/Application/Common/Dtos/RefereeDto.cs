using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public class RefereeDto : IMapFrom<RefereeModel>
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Institution { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public int? Applicant { get; set; }
}

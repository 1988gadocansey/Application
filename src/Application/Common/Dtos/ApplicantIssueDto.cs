using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record ApplicantIssueDto : IMapFrom<ApplicantIssueModel>
{
    public int Id { set; get; }
    public int ApplicantId { set; get; }
    public string? Issue { set; get; }

}

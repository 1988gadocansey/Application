using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Application.Common.Mappings;
namespace ApplicantPortal.Application.Common.Dtos;
public record SHSAttendedDto : IMapFrom<SHSAttendedModel>
{
    public int Id { set; get; }
    public bool AttendedTTU { get; set; }
    public ApplicantModel? Applicant { get; set; }
    public FormerSchoolModel? Name { set; get; }
    public RegionModel? Location { set; get; }
    public int? StartYear { set; get; }
    public int? EndYear { set; get; }
    public string? ProgrammeStudied { get; set; }

}

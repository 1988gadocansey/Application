using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record ProgressDto : IMapFrom<ProgressModel>
{
    public string? ApplicationUserId { set; get; }
    public bool? Biodata { set; get; }
    public bool Results { set; get; }
    public bool Picture { set; get; }
    public bool Age { set; get; }
    public bool FormCompletion { set; get; }
    public bool Qualification { set; get; }
    public bool? DocumentUpload { set; get; }
    public bool? WorkingExperience { set; get; }
    public bool? AcademicExperience { set; get; }
    public bool? ResearchInformation { set; get; }
    public bool? ResearchPublication { set; get; }
    public bool? Referee { set; get; }
}

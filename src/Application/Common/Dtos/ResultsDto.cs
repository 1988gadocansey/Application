using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record ResultsDto : IMapFrom<ResultUploadModel>
{
    public int Id { set; get; }
    public int SubjectId { set; get; }
    public string? ExamType { set; get; }
    public int GradeId { set; get; }
    public int? GradeOld { set; get; }
    public string? GradeValueOld { set; get; }
    public string? IndexNo { set; get; }
    public string? Sitting { set; get; }
    public string? Month { set; get; }
    public int Form { set; get; }
    public string? Center { set; get; }
    public string? Year { set; get; }
    public string? OldSubject { set; get; }
    public string? InstitutionName { set; get; }
    public int ApplicantId { set; get; }

    public virtual ApplicantModel? Applicant{ get; set; }

    public virtual SubjectModel? Subject { get; set; }

    public virtual GradeModel? Grade { get; set; }


}

namespace ApplicantPortal.Application.Results.Commands;
public record CreateResultRequest : IRequest<int>
{

    public int Applicant { set; get; }
    public int? SubjectId { set; get; }
    public string? ExamType { set; get; }
    public int? GradeId { set; get; }
    public string? IndexNo { set; get; }
    public string? Sitting { set; get; }
    public string? Month { set; get; }
    public string? Center { set; get; }
    public string? Year { set; get; }
    public string? InstitutionName { set; get; }


}

namespace ApplicantPortal.Application.UniversityAttended.Commands;
public record UniversityAttendedRequest : IRequest<int>
{
    public int? Id { set; get; }
    public string? Name { set; get; }
    public int Location { set; get; }
    public string? StartYear { set; get; }
    public string? EndYear { set; get; }
    public string? StudentNumber { set; get; }
    public string? DegreeObtained { set; get; }
    public string? DegreeClassification { set; get; }
    public decimal? CGPA { set; get; }
    public int? Applicant { get; set; }

}

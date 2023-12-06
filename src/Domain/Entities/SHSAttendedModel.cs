using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantPortal.Domain.Entities
{
    public record SHSAttendedModel
    {
        [Key]
        public int Id { set; get; }
        public bool AttendedTTU { get; set; }
        public ApplicantModel? Applicant { get; set; }
        public FormerSchoolModel? Name { set; get; }
        public RegionModel? Location { set; get; }
        public int? StartYear { set; get; }
        public int? EndYear { set; get; }
        public string? ProgrammeStudied { get; set; }



    }
}

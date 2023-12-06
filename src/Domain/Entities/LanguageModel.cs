using System.ComponentModel.DataAnnotations;

namespace ApplicantPortal.Domain.Entities
{
    public record LanguageModel
    {

        [Key]
        public int Id { set; get; }
        public string? Name { set; get; }
        public int ApplicantModelID { set; get; }
        private IEnumerable<ApplicantModel>? ApplicantModel { get; set; }


    }
}

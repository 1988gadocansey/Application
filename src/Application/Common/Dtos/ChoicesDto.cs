using ApplicantPortal.Application.Common.Mappings;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Common.Dtos;

public record ChoicesDto : IMapFrom<ProgrammeModel>
{
    public int Id { set; get; }
    public ProgrammeModel? FirstChoice { set; get; }
    public ProgrammeModel? SecondChoice { set; get; }
    public ProgrammeModel? ThirdChoice { set; get; }
}

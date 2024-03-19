using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.SelectBoxItems;

public class GetProgrammeByIdQuery : IRequest<ProgrammeDto>
{
    public int Id { get; set; }
    public class GetProgrammeByIdQueryHandler(
        IApplicationDbContext context,
        
        IMapper mapper)
        : IRequestHandler<GetProgrammeByIdQuery, ProgrammeDto>
    {
        
        public async Task<ProgrammeDto> Handle(GetProgrammeByIdQuery query, CancellationToken cancellationToken)
        {

            var programme = await context.ProgrammeModels.FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

            return mapper.Map<ProgrammeDto>(programme);
        }
    }
}

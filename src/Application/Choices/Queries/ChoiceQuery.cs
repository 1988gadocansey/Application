using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
namespace ApplicantPortal.Application.Choices.Queries;

public record Choicequery : IRequest<ChoicesDto>;

public class GetChoiceQueryHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    IMapper mapper)
    : IRequestHandler<Choicequery, ChoicesDto>
{
    public async Task<ChoicesDto> Handle(Choicequery request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;

        var applicant = await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId,
            cancellationToken: cancellationToken);

        var data = await context.Choices.FirstOrDefaultAsync(a => a.Applicant == applicant,
            cancellationToken: cancellationToken);
        return mapper.Map<ChoicesDto>(data);
    }
}

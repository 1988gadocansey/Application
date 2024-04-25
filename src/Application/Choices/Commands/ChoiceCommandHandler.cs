using ApplicantPortal.Application.Address.Commands;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Choices.Commands;

public class ChoiceCommandHandler(
    IUser currentUserService,
    IApplicationDbContext context) : IRequestHandler<ChoiceRequest, int>
{
    public async Task<int> Handle(ChoiceRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;

        var applicant = await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId,
            cancellationToken: cancellationToken);
        var check =  await context.Choices.AnyAsync(a => a.Applicant == applicant, cancellationToken: cancellationToken);

        if (check==false)
        {
            var choice = new Domain.Entities.Choices
            {
                FirstChoice = request.FirstChoice,
                SecondChoice = request.SecondChoice,
                ThirdChoice = request.ThirdChoice,
                Applicant = applicant,
            };
            await context.Choices.AddAsync(choice, cancellationToken);
        }
        else
        {
            var choice = await context.Choices.FirstOrDefaultAsync(a => a.Applicant == applicant, cancellationToken: cancellationToken);
            choice!.FirstChoice = request.FirstChoice;
            choice!.ThirdChoice = request.ThirdChoice;
            choice!.SecondChoice = request.SecondChoice;
            context.Choices.Update(choice);
        }
        return await context.SaveChangesAsync(cancellationToken);
    }
}

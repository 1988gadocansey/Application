using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Biodata.Commands.UpdateBiodata;

public class UpdateBiodataCommandHandler(IApplicationDbContext context, IUser currentUserService, IDateTime dateTime)
    : IRequestHandler<UpdateBiodataRequest>
{
    private readonly IDateTime _dateTime = dateTime;

    public async Task Handle(UpdateBiodataRequest request, CancellationToken cancellationToken)
    {
        var applicant = await context.ApplicantModels
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), request.Id.ToString());
        }
        applicant.Title = request.Title;
        applicant.ApplicationUserId = currentUserService.Id;
        applicant.ApplicationNumber = Domain.ValueObjects.ApplicationNumber.Create(request.ApplicationNumber);
        applicant.ApplicantName = Domain.ValueObjects.ApplicantName.Create(request.FirstName, request.LastName, request.OtherName!);
        applicant.Title = request.Title;
        applicant.Gender = request.Gender;
        applicant.Email = Domain.ValueObjects.EmailAddress.Create(request.Email);
        context.ApplicantModels.Add(applicant);
        await context.SaveChangesAsync(cancellationToken);

        

    }
}

using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using OnlineApplicationSystem.Application.Preview.Commands;

namespace ApplicantPortal.Application.Preview.Commands;

public class FinalizedCommandHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    IApplicantRepository applicantRepository,
    IIdentityService identityService,
    IEmailSender emailSender,
    ISmsSender smsSender)
    : IRequestHandler<FinalizedRequest, int>
{
    public async Task<int> Handle(FinalizedRequest request, CancellationToken cancellationToken)
    {
        const string email = "hello";
        const string? subject = "TTU Admissions";
        const string? body = "Your Admission Form has been received.";
        const string? from = "TTU Admissions";
        var userFormDetails = await identityService.GetApplicationUserDetails(currentUserService.Id, cancellationToken);
        var core = new int[8];
        var coreAlt = new int[7];
        var electives = new int[20];
        var applicant = await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == currentUserService.Id, cancellationToken);
        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), currentUserService.Id!);
        }
        var qualifiesMatured = await applicantRepository.QualifiesMature(applicant.Age);
        // go through issue table to see if there are issues to prevent him from finalizing
        //lets create issue flag here
        var applicantIssues = context.ProgressModels.FirstOrDefaultAsync(u => u.ApplicationUserId == currentUserService.Id, cancellationToken: cancellationToken);

        if (applicantIssues != null)
        {
            applicantIssues.Result = true;
            applicantIssues.FormCompletion = true;
            context.ProgressModels.Update(applicantIssues);
        }
        await context.SaveChangesAsync(cancellationToken);

        if (applicantIssues.Picture == false || applicantIssues.FormCompletion == false || applicantIssues.Referee == false || applicantIssues.ResearchInformation == false || applicantIssues.AcademicExperience == false)
        {
            // throw new NotFoundException(nameof(ApplicantModel), request.Id);
            //  throw new NotFoundException("Error finalizing form. Check.", request.Id);
            return 0;
        }
        var smsMessage = "Hi " + applicant.ApplicantName!.FirstName + " your application has been received. Vist apply.ttuportal.com with " + userFormDetails.UserName + " as serial and " + userFormDetails.Pin + " as pin to check your admission status.";
        var emailMessage = "Hi " + applicant.ApplicantName.FirstName + " your application has been received. Vist apply.ttuportal.com with " + userFormDetails.UserName + " as serial and " + userFormDetails.Pin + " as pin to check your admission status.";
        // update the applicant issues
        applicantIssues.FormCompletion = true;
        applicantIssues.Age = qualifiesMatured;
        context.ProgressModels.Update(applicantIssues);
        await context.SaveChangesAsync(cancellationToken);
        await identityService.Finalized(currentUserService.UserId);
        var mailData = new MailData(
              new List<string> { applicant.Email.Value },
              "TTU Admissions Forms",
               body,
              "TTU",
              "TTU",
              "admissions@ttu.edu.gh",
              "TTU Admissions",
               new List<string> { "admissions@ttu.edu.gh" },
               new List<string> { "gadocansey@gmail.com" }
            );

        // await _emailSender.SendEmail(mailData, cancellationToken);
        await emailSender.SendEmail(applicant.Email.Value, subject, emailMessage, from);
        await smsSender.SendSms(applicant.Phone.Number, smsMessage, applicant.ApplicationNumber.ApplicantNumber, currentUserService.UserId, cancellationToken);
        return 1;
    }
}

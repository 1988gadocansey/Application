using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Results.Commands;

public class CreateResultCommandHandler(
    IApplicationDbContext context,
    IApplicantRepository applicantRepository,
    IUser currentUserService,
    IIdentityService identityService)
    : IRequestHandler<CreateResultRequest, int>
{
    public async Task<int> Handle(CreateResultRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var formNo = userDetails.FormNo;
        var applicantDetails = await applicantRepository.GetApplicantForUser(userId, cancellationToken);
        var subject = await context.SubjectModels.FirstOrDefaultAsync(s => s.Id == request.SubjectId, cancellationToken: cancellationToken);
        var grade = await context.GradeModels.FirstOrDefaultAsync(s => s.Id == request.GradeId, cancellationToken: cancellationToken);
        if (userDetails.Category != "Undergraduate" || userDetails.ForeignApplicant == true)   throw new NotFoundException(nameof(ResultUploadModel), request.IndexNo!);

        if (await context.ResultUploadModels.AnyAsync(c =>
                                 c.Subject == subject && c.Grade == grade && c.Year == request.Year!  &&
                                 c.ExamType == request.ExamType && c.IndexNo == request.IndexNo!  &&
                                 c.Sitting == request.Sitting && c.Month == request.Month!  &&
                                 c.ApplicantModelId == applicantDetails.Id, cancellationToken: cancellationToken) == true)
        {
            throw new NotFoundException(nameof(ResultUploadModel), "Grade Exist");
        }
        var resultDetails = new ResultUploadModel
        {
            Subject = subject,
            Form =  Convert.ToInt32(formNo),
            Sitting = request.Sitting,
            Year = request.Year,
            ApplicantModelId = applicantDetails.Id,
            ExamType = request.ExamType,
            Center = request.Center,
            IndexNo = request.IndexNo,
            Month = request.Month,
            Grade = grade
        };
        await context.ResultUploadModels.AddAsync(resultDetails, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
         
            // check if result uploaded is 6 and above

            if (context.ResultUploadModels.Count(a => a.ApplicantModelId == applicantDetails.Id) >= 6)
            {
                var applicantIssues = context.ProgressModels.FirstOrDefault(u => u.ApplicationUserId == currentUserService.Id);
                if (applicantIssues != null)
                {
                    applicantIssues.Results = true;
                    applicantIssues.FormCompletion = true;
                    context.ProgressModels.Update(applicantIssues);
                }
                await context.SaveChangesAsync(cancellationToken);
                // grade the applicant if hes a wassce or ssce
                if (applicantDetails.FirstQualification == "WASSCE" || applicantDetails.FirstQualification == "SSCE")
                {
                    var Core = new List<int>();
                    var CoreAlt = new List<int>();
                    var Electives = new List<int>();
                    var results = context.ResultUploadModels.Include(g => g.Grade).Include(s => s.Subject).Where(r => r.ApplicantModelId == applicantDetails.Id);
                    foreach (var score in results)
                    {
                        switch (score.Subject!.Code)
                        {
                            case "core":
                                Core.Add(Convert.ToInt32(score.Grade!.Value));
                                break;
                            case "core_alt":
                                CoreAlt.Add(Convert.ToInt32(score.Grade!.Value));
                                break;
                            case "elective":
                                Electives.Add(Convert.ToInt32(score.Grade!.Value)); ;
                                break;
                        }
                    }
                    var gradeValues = new List<int>();
                    gradeValues.AddRange(Core);
                    gradeValues.AddRange(CoreAlt);
                    gradeValues.AddRange(Electives);
                    int failed = applicantRepository.CheckFailed(gradeValues);
                    int passed = applicantRepository.CheckPassed(gradeValues);
                    int totalGrade = applicantRepository.GetTotalAggregate(Core, CoreAlt, Electives);
                    //Console.Write($"total pass is {passed}, failed is {failed}, grade is {totalGrade}");


                    var applicantData = await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
                    applicantData!.Grade = totalGrade;
                    applicantData.Results = "Total Failed: " + failed + ", Total Passed " + passed;
                    await context.SaveChangesAsync(cancellationToken);
                }
            }

            return resultDetails.Id;
        

    }
}

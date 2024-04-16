using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.ValueObjects;
using Microsoft.Extensions.Logging;


namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandHandler(
    IApplicationDbContext context,
    IUser currentUserService,
    IIdentityService identityService,
    IApplicantRepository applicantRepository
)
    : IRequestHandler<CreateBiodataRequest, int>
{
    public async Task<int> Handle(CreateBiodataRequest request, CancellationToken cancellationToken)
    {
        string? userId = currentUserService.Id;
        UserDto userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        RegionModel? region =
            await context.RegionModels.FirstOrDefaultAsync(s => s.Id == request.RegionId, cancellationToken);
        ReligionModel? religion =
            await context.ReligionModels.FirstOrDefaultAsync(s => s.Id == request.ReligionId, cancellationToken);
        DistrictModel? district =
            await context.DistrictModels.FirstOrDefaultAsync(s => s.Id == request.District, cancellationToken);
        CountryModel? nationality =
            await context.CountryModels.FirstOrDefaultAsync(s => s.Id == request.NationalityId, cancellationToken);
        ConfigurationModel? calender = await applicantRepository.GetConfiguration();
        // var FormerSchool = _context.FormerSchoolModels.FirstOrDefault(s => s.Id == request.SC);
        var applicantSearch = context.ApplicantModels.Where(s => s.ApplicationUserId == userId);
        if (!applicantSearch.Any())
        {
            var applicant = new ApplicantModel
            {
                ApplicationUserId = userId,
                ApplicationNumber = ApplicationNumber.Create(Convert.ToInt64(userDetails.FormNo)),
                ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request.OtherName!),
                PreviousName = ApplicantName.Create(request.PreviousName, request.PreviousName, null!),
                Title = request.Title,
                Gender = request.Gender,
                Email = EmailAddress.Create(request.Email),
                MaritalStatus = request.MaritalStatus,
                Dob = request.DateOfBirth,
                NoOfChildren = request.NoOfChildren,
                Age = await applicantRepository.GetAge(request.DateOfBirth!),
                Phone = PhoneNumber.Create(request.Phone, "233"),
                AltPhone = PhoneNumber.Create(request.AltPhone, "233"),
                EmergencyContact = PhoneNumber.Create(request.EmergencyContact, "233"),
                Referrals = request.Referrals,
                NationalityId = request.NationalityId,
                Region = region,
                Religion = religion,
                District = district,
                Denomination = request.Denomination,
                Nationality = nationality,
                Disability = request.Disability,
                //DisabilityType = request.DisabilityType,
                IdCard = IdCard.Create(request.IdCard.ToString(), request.NationalIDNo!),
                ResidentialStatus = request.ResidentialStatus,
                Hometown = request.Hometown!.ToUpper(),
                GuardianName = request.GuardianName?.ToUpper(),
                GuardianOccupation = request.GuardianOccupation!.ToUpper(),
                GuardianPhone = PhoneNumber.Create(request.GuardianPhone, "233"),
                GuardianRelationship = request.GuardianRelationship,
                YearOfAdmission = calender!.Year,
                Admitted = false,
                HallFeesPaid = Money.Create("GHS", 0)
            };

            await context.ApplicantModels.AddAsync(applicant, cancellationToken);
            await applicantRepository.UpdateFormNo(cancellationToken);

            // now add languages
            if (request.Languages!.Length > 0)
            {
                // int id = 1;
                foreach (var language in request.Languages!)
                {
                    var languages = new LanguageModel()
                    {
                        // Id = id,
                        Name = language.ToString(), Applicant = applicant.Id,
                    };

                    await context.Languages.AddAsync(languages, cancellationToken);
                    // id++;
                }
            }

            // now add disabilities if any
            if ((bool)request.Disability!)
            {
                foreach (var disability in request.DisabilityType!)
                {
                    var disabilityIssue = new DisabilitiesModel()
                    {
                        ApplicantModelId = applicant.Id, Name = disability.ToString()
                    };
                    await context.DisabilitiesModels.AddAsync(disabilityIssue, cancellationToken);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var applicant = await context.ApplicantModels
                .FindAsync(new object[] { request.Id! }, cancellationToken);

            if (applicant == null)
            {
                throw new NotFoundException(nameof(ApplicantModel), request!.Id.ToString()!);
            }

            applicant.Title = request.Title;
            applicant.ApplicationUserId = currentUserService.Id;
            applicant.ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request!.OtherName!);
            applicant.Title = request.Title;
            applicant.Gender = request.Gender;
            applicant.Email = EmailAddress.Create(request.Email);
            applicant.MaritalStatus = request.MaritalStatus;
            applicant.NoOfChildren = request.NoOfChildren;
            applicant.Dob = request.DateOfBirth;
            applicant.Age = await applicantRepository.GetAge(request.DateOfBirth!);
            applicant.Phone = PhoneNumber.Create(request.Phone, "233");
            applicant.AltPhone = PhoneNumber.Create(request.AltPhone, "233");
            applicant.EmergencyContact = PhoneNumber.Create(request.EmergencyContact, "233");
            applicant.Referrals = request.Referrals;
            applicant.NationalityId = request.NationalityId;
            applicant.Region = region;
            applicant.Religion = religion;
            applicant.Denomination = request.Denomination;
            applicant.District = district;
            applicant.Nationality = nationality;
            applicant.Disability = request.Disability;
            // applicant.DisabilityType = request.DisabilityType;
            applicant.IdCard = IdCard.Create(request.IdCard.ToString(), request.NationalIDNo!);
            applicant.ResidentialStatus = request.ResidentialStatus;
            applicant.Hometown = request.Hometown!.ToUpper();
            applicant.GuardianName = request.GuardianName!.ToUpper();
            applicant.GuardianOccupation = request.GuardianOccupation!.ToUpper();
            applicant.GuardianPhone = PhoneNumber.Create(request.GuardianPhone, "233");
            applicant.GuardianRelationship = request.GuardianRelationship;
            await context.SaveChangesAsync(cancellationToken);
            // now add languages
            if (request.Languages!.Length > 0)
            {
                var recordsToDelete = await context.Languages
                    .Where(item => item.Applicant == request.Id)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (recordsToDelete.Count != 0)
                {
                    context.Languages.RemoveRange(recordsToDelete);
                    await context.SaveChangesAsync(cancellationToken);
                }

                foreach (var language in request.Languages!)
                {
                    var languages = new LanguageModel() { Name = language.ToString(), Applicant = applicant.Id, };
                    await context.Languages.AddAsync(languages, cancellationToken);
                }
            }

            // now add disabilities if any
            if ((bool)request.Disability!)
            {
                var recordsToDelete = await context.DisabilitiesModels
                    .Where(item => item.ApplicantModelId == request.Id)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (recordsToDelete.Count != 0)
                {
                    context.DisabilitiesModels.RemoveRange(recordsToDelete);
                    await context.SaveChangesAsync(cancellationToken);
                }

                foreach (var disability in request.DisabilityType!)
                {
                    var disabilityIssue = new DisabilitiesModel()
                    {
                        ApplicantModelId = applicant.Id, Name = disability.ToString()
                    };
                    await context.DisabilitiesModels.AddAsync(disabilityIssue, cancellationToken);
                }
            }
        }

        // go to issue and update biodata done as true
        var applicantIssues = await context.ProgressModels
            .FirstOrDefaultAsync(u => u.ApplicationUserId == currentUserService.Id, cancellationToken);

        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            context.ProgressModels.Update(applicantIssues);
        }
        else
        {
            applicantIssues = new ProgressModel // Assuming ProgressModel is the type
            {
                ApplicationUserId = currentUserService.Id, Biodata = true
            };
            context.ProgressModels.Add(applicantIssues);
        }

        await context.SaveChangesAsync(cancellationToken);
        return applicantIssues.Id;
    }
}

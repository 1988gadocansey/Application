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
         
        Console.WriteLine($"firstname is  {request.FirstName}");
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
                Age = 0,
                Phone = PhoneNumber.Create(request.Phone),
                AltPhone = PhoneNumber.Create(request.AltPhone),
                EmergencyContact = PhoneNumber.Create(request.EmergencyContact),
                Referrals = request.Referrals,
                NationalityId = request.NationalityId,
                Region = region,
                Religion = religion,
                District = district,
                Denomination = request.Denomination,
                Nationality = nationality,
                Disability = request.Disability,
                DisabilityType = request.DisabilityType,
                IdCard = IdCard.Create(request.IdCard.ToString(), request.NationalIDNo!),
                ResidentialStatus = request.ResidentialStatus,
                SourceOfFinance = request.SourceOfFinance!.ToUpper(),
                Hometown = request.Hometown!.ToUpper(),
                GuardianName = request.GuardianName?.ToUpper(),
                GuardianOccupation = request.GuardianOccupation!.ToUpper(),
                GuardianPhone = PhoneNumber.Create(request.GuardianPhone),
                GuardianRelationship = request.GuardianRelationship,
                SponsorShip = request.Sponsorship,
                SponsorShipCompany = request.SponsorshipCompany,
                SponsorShipCompanyContact = request.SponsorshipCompanyContact,
                SponsorShipLocation = request.SponsorshipLocation,
                YearOfAdmission = calender!.Year,
                Admitted = false,
              //  PreviousIndexNumber = request.PreviousIndexNumber,
                HallFeesPaid = Money.Create("GHS", 0)
            };

            await context.ApplicantModels.AddAsync(applicant, cancellationToken);
            // await _applicantRepository.UpdateFormNo(cancellationToken);
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
            // applicant.ApplicationNumber = ApplicationNumber.Create(request.ApplicationNumber);
            applicant.ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request!.OtherName!);
            applicant.Title = request.Title;
            applicant.Gender = request.Gender;
            applicant.Email = EmailAddress.Create(request.Email);
            applicant.MaritalStatus = request.MaritalStatus;
            applicant.NoOfChildren = request.NoOfChildren;
            applicant.Dob = request.DateOfBirth;
            applicant.Phone = PhoneNumber.Create(request.Phone);
            applicant.AltPhone = PhoneNumber.Create(request.AltPhone);
            applicant.EmergencyContact = PhoneNumber.Create(request.EmergencyContact);
            applicant.Referrals = request.Referrals;
            applicant.NationalityId = request.NationalityId;
            applicant.Region = region;
            applicant.Religion = religion;
            applicant.Denomination = request.Denomination;
            applicant.District = district;
            applicant.Nationality = nationality;
            applicant.Disability = request.Disability;
            applicant.DisabilityType = request.DisabilityType;
            applicant.IdCard = IdCard.Create(request.IdCard.ToString(), request.NationalIDNo!);
            applicant.ResidentialStatus = request.ResidentialStatus;
            applicant.SourceOfFinance = request.SourceOfFinance!.ToUpper();
            applicant.Hometown = request.Hometown!.ToUpper();
            applicant.GuardianName = request.GuardianName!.ToUpper();
            applicant.GuardianOccupation = request.GuardianOccupation!.ToUpper();
            applicant.GuardianPhone = PhoneNumber.Create(request.GuardianPhone);
            applicant.GuardianRelationship = request.GuardianRelationship;
            applicant.SponsorShip = request.Sponsorship;
            applicant.SponsorShipCompany = request.SponsorshipLocation;
            applicant.SponsorShipCompanyContact = request.SponsorshipCompanyContact;
            applicant.SponsorShipLocation = request.SponsorshipLocation;
            //await _context.ApplicantModels.AddAsync(applicant, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        // go to issue and update biodata done as true
        var applicantIssues =
            await context.ProgressModels.FirstOrDefaultAsync(u => u.ApplicationUserId == currentUserService.Id,
                cancellationToken);
        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            context.ProgressModels.Update(applicantIssues);
        }

        await context.SaveChangesAsync(cancellationToken);
        return applicantIssues!.Id;
    }
}

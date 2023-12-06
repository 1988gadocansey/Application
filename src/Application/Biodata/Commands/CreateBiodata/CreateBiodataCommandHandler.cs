using MediatR;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.ValueObjects;
using ApplicantPortal.Domain.Enums;
using ApplicantPortal.Application.Common.Exceptions;

namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandHandler(IApplicationDbContext context, IUser  currentUserService,   IIdentityService identityService, IApplicantRepository applicantRepository) : IRequestHandler<CreateBiodataRequest, int>
{
   
      
    public async Task<int> Handle(CreateBiodataRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var region = await context.RegionModels.FirstOrDefaultAsync(s => s.Id == request.RegionId,cancellationToken);
        var religion = await context.ReligionModels.FirstOrDefaultAsync(s => s.Id == request.ReligionId,cancellationToken);
        var district = await context.DistrictModels.FirstOrDefaultAsync(s => s.Id == request.District,cancellationToken);
        var nationality = await context.CountryModels.FirstOrDefaultAsync(s => s.Id == request.NationalityId,cancellationToken);
        var calender = await applicantRepository.GetConfiguration();
        // var FormerSchool = context.FormerSchoolModels.FirstOrDefault(s => s.Id == request.SC);
        var applicantSearch = context.ApplicantModels.Where(s => s.ApplicationUserId == userId);
        if (!applicantSearch.Any())
        {
            var applicant = new ApplicantModel
            {
                ApplicationUserId = userId,
                ApplicationNumber = ApplicationNumber.Create(Convert.ToInt64(userDetails.FormNo)),
                ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request.OtherName!),
                PreviousName = ApplicantName.Create(request.PreviousName, request.PreviousName, request.OtherName!),
                Title = request.Title,
                Gender = request.Gender,
                Email = EmailAddress.Create(request.Email),
                MaritalStatus = request.MaritalStatus,
                Dob = request.Dob,
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
                IdCard = IdCard.Create(request.NationalIdType.ToString()!, request.NationalIdNo!),
                ResidentialStatus = request.ResidentialStatus,
                SourceOfFinance = request.SourceOfFinance?.ToUpper(),
                Hometown = request.Hometown?.ToUpper(),
                GuardianName = request.GuardianName?.ToUpper(),
                GuardianOccupation = request.GuardianOccupation?.ToUpper(),
                GuardianPhone = PhoneNumber.Create(request.GuardianPhone),
                GuardianRelationship = request.GuardianRelationship,
                SponsorShip = request.SponsorShip,
                SponsorShipCompany = request.SponsorShipCompany,
                SponsorShipCompanyContact = request.SponsorShipCompanyContact,
                SponsorShipLocation = request.SponsorShipLocation,
                YearOfAdmission = calender?.Year,
                Admitted = false,
                HallFeesPaid = Money.Create("GHS", 0)

            };

            await context.ApplicantModels.AddAsync(applicant, cancellationToken);
            // await applicantRepository.UpdateFormNo(cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var applicant = await context.ApplicantModels.FindAsync(new object[] { request.Id }, cancellationToken);

            if (applicant == null)
            {
                throw new NotFoundException(nameof(ApplicantModel), request.Id.ToString());
            }
            applicant.Title = request.Title;
            applicant.ApplicationUserId = currentUserService.Id;
            // applicant.ApplicationNumber = ApplicationNumber.Create(request.ApplicationNumber);
            applicant.ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request.OtherName!);
            applicant.Title = request.Title;
            applicant.Gender = request.Gender;
            applicant.Email = EmailAddress.Create(request.Email);
            applicant.MaritalStatus = request.MaritalStatus;
            applicant.NoOfChildren = request.NoOfChildren;
            applicant.Dob = request.Dob;
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
            applicant.IdCard = IdCard.Create(request.NationalIdType.ToString()!, request.NationalIdNo!);
            applicant.ResidentialStatus = request.ResidentialStatus;
            applicant.SourceOfFinance = request.SourceOfFinance!.ToUpper();
            applicant.Hometown = request.Hometown!.ToUpper();
            applicant.GuardianName = request.GuardianName!.ToUpper();
            applicant.GuardianOccupation = request.GuardianOccupation!.ToUpper();
            applicant.GuardianPhone = PhoneNumber.Create(request.GuardianPhone);
            applicant.GuardianRelationship = request.GuardianRelationship;
            applicant.SponsorShip = request.SponsorShip;
            applicant.SponsorShipCompany = request.SponsorShipCompany;
            applicant.SponsorShipCompanyContact = request.SponsorShipCompanyContact;
            applicant.SponsorShipLocation = request.SponsorShipLocation;
            //await context.ApplicantModels.AddAsync(applicant, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        // go to issue and update biodata done as true
        var applicantIssues = await context.ProgressModels.FirstOrDefaultAsync(u => u.ApplicationUserId == currentUserService.Id, cancellationToken);
        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            context.ProgressModels.Update(applicantIssues);
        }
        var result = await context.SaveChangesAsync(cancellationToken);
        return result == 1 ? 200 : 500;
    }
}

using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.ValueObjects;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandHandler : IRequestHandler<CreateBiodataRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;

    public CreateBiodataCommandHandler(IApplicationDbContext context, IUser currentUserService, IDateTime dateTime,
        IIdentityService identityService, IApplicantRepository applicantRepository)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
    }

    public async Task<int> Handle(CreateBiodataRequest request, CancellationToken cancellationToken)
    {
        string? userId = _currentUserService.Id;
        UserDto userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        RegionModel? region =
            await _context.RegionModels.FirstOrDefaultAsync(s => s.Id == request.RegionId, cancellationToken);
        ReligionModel? religion =
            await _context.ReligionModels.FirstOrDefaultAsync(s => s.Id == request.ReligionId, cancellationToken);
        DistrictModel? district =
            await _context.DistrictModels.FirstOrDefaultAsync(s => s.Id == request.District, cancellationToken);
        CountryModel? nationality =
            await _context.CountryModels.FirstOrDefaultAsync(s => s.Id == request.NationalityId, cancellationToken);
        ConfigurationModel? calender = await _applicantRepository.GetConfiguration();
        // var FormerSchool = _context.FormerSchoolModels.FirstOrDefault(s => s.Id == request.SC);
        var applicantSearch = _context.ApplicantModels.Where(s => s.ApplicationUserId == userId);
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
                PreviousIndexNumber = request.PreviousIndexNumber,
                HallFeesPaid = Money.Create("GHS", 0)
            };

            await _context.ApplicantModels.AddAsync(applicant, cancellationToken);
            // await _applicantRepository.UpdateFormNo(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var applicant = await _context.ApplicantModels
                .FindAsync(new object[] { request.Id! }, cancellationToken);

            if (applicant == null)
            {
                throw new NotFoundException(nameof(ApplicantModel), request!.Id.ToString()!);
            }

            applicant.Title = request.Title;
            applicant.ApplicationUserId = _currentUserService.Id;
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
            await _context.SaveChangesAsync(cancellationToken);
        }

        // go to issue and update biodata done as true
        var applicantIssues =
            await _context.ProgressModels.FirstOrDefaultAsync(u => u.ApplicationUserId == _currentUserService.Id,
                cancellationToken);
        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            _context.ProgressModels.Update(applicantIssues);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return applicantIssues!.Id;
    }
}

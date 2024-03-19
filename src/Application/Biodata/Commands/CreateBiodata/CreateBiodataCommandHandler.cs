using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
using ApplicantPortal.Domain.ValueObjects;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandHandler : IRequestHandler<CreateBiodataRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;

    public CreateBiodataCommandHandler(IApplicationDbContext context, IUser currentUserService, IDateTime dateTime, IIdentityService identityService, IApplicantRepository applicantRepository)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
    }
    public async Task<int> Handle(CreateBiodataRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.Id;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var region = _context.RegionModels.FirstOrDefault(s => s.Id == request.RegionId);
        var religion = _context.ReligionModels.FirstOrDefault(s => s.Id == request.ReligionId);
        var district = _context.DistrictModels.FirstOrDefaultAsync(s => s.Id == request.District, cancellationToken);
        var nationality = _context.CountryModels.FirstOrDefaultAsync(s => s.Id == request.NationalityId,cancellationToken);
        var calender = await _applicantRepository.GetConfiguration();
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
                Idcard = IDCard.Create(request.NationalIDNo, request.NationalIDType.ToString()),
                ResidentialStatus = request.ResidentialStatus,
                SourceOfFinance = request.SourceOfFinance.ToUpper(),
                Hometown = request.Hometown.ToUpper(),
                GuardianName = request.GuardianName?.ToUpper(),
                GuardianOccupation = request.GuardianOccupation.ToUpper(),
                GuardianPhone = PhoneNumber.Create(request.GuardianPhone),
                GuardianRelationship = request.GuardianRelationship,
                SponsorShip = request.SponsorShip,
                SponsorShipCompany = request.SponsorShipCompany,
                SponsorShipCompanyContact = request.SponsorShipCompanyContact,
                SponsorShipLocation = request.SponsorShipLocation,
                YearOfAdmission = calender.Year,
                Admitted = false,
                HallFeesPaid = Money.Create("GHS", 0)

            };

            await _context.ApplicantModels.AddAsync(applicant, cancellationToken);
            // await _applicantRepository.UpdateFormNo(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var applicant = await _context.ApplicantModels
            .FindAsync(new object[] { request.Id }, cancellationToken);

            if (applicant == null)
            {
                throw new NotFoundException(nameof(ApplicantModel), request.Id);
            }
            applicant.Title = request.Title;
            applicant.ApplicationUserId = _currentUserService.UserId;
            // applicant.ApplicationNumber = ApplicationNumber.Create(request.ApplicationNumber);
            applicant.ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request.OtherName);
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
            applicant.Idcard = IDCard.Create(request.NationalIDNo, request.NationalIDType.ToString());
            applicant.ResidentialStatus = request.ResidentialStatus;
            applicant.SourceOfFinance = request.SourceOfFinance.ToUpper();
            applicant.Hometown = request.Hometown.ToUpper();
            applicant.GuardianName = request.GuardianName.ToUpper();
            applicant.GuardianOccupation = request.GuardianOccupation.ToUpper();
            applicant.GuardianPhone = PhoneNumber.Create(request.GuardianPhone);
            applicant.GuardianRelationship = request.GuardianRelationship;
            applicant.SponsorShip = request.SponsorShip;
            applicant.SponsorShipCompany = request.SponsorShipCompany;
            applicant.SponsorShipCompanyContact = request.SponsorShipCompanyContact;
            applicant.SponsorShipLocation = request.SponsorShipLocation;
            //await _context.ApplicantModels.AddAsync(applicant, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // go to issue and update biodata done as true
        var applicantIssues = _context.ProgressModels.FirstOrDefault(u => u.ApplicationUserId == _currentUserService.UserId);
        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            _context.ProgressModels.Update(applicantIssues);
        }
        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1 ? 200 : 500;
    }
}

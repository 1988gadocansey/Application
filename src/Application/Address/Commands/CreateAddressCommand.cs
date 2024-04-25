using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;
namespace ApplicantPortal.Application.Address.Commands;


public class CreateAddressCommand( IUser currentUserService,
    IApplicationDbContext context,
    IIdentityService identityService) : IRequestHandler<CreateAddressRequest, int>
{
   
    public async Task<int> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicant = await context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId, cancellationToken: cancellationToken);
        var check =   context.AddressModels.Any(a => a.Applicant == applicant && a.Box == request.Box
                                                                              && a.Gprs == request.Gprs && a.City == request.City
                                                                              && a.HouseNumber == request.HouseNumber);
        if ( check== false)
        {
            var address = new AddressModel
            {
                Street = request.Street,
                City = request.City,
                Box = request.Box,
                HouseNumber = request.HouseNumber,
                Gprs = request.Gprs,
                Applicant = applicant
            };
            await context.AddressModels.AddAsync(address, cancellationToken);


        }
        else
        {
            var address = context.AddressModels
                .SingleOrDefault(a => a.Applicant == applicant && a.Box == request.Box
                                                               && a.Gprs == request.Gprs && a.City == request.City
                                                               && a.HouseNumber == request.HouseNumber);
            if (address!.HouseNumber != "")
            {
                address.Street = request.Street;
                address.City = request.City;
                address.HouseNumber = request.HouseNumber;
                address.Box = request.Box;
                address.Gprs = request.Gprs;
                context.AddressModels.Update(address);
            }

        }
        return  await context.SaveChangesAsync(cancellationToken);

    }
}

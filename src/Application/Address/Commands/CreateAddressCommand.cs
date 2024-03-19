using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Application.Address.Commands;


public class CreateAddressCommand( IUser currentUserService,
    IApplicationDbContext context,
    IIdentityService identityService) : IRequestHandler<CreateAddressRequest, Guid>
{
   
    public async Task<Guid> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var userId = currentUserService.Id;
        var userDetails = await identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicant = context.ApplicantModels.FirstOrDefault(a => a.ApplicationUserId == userId);

        if ( request.City == null)
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
            var address = context.AddressModels.FirstOrDefault(a => a.Applicant == applicant);
            if (address != null)
            {
                address.Street = request.Street;
                address.City = request.City;
                address.HouseNumber = request.HouseNumber;
                address.Box = request.Box;
                address.Gprs = request.Gprs;
                context.AddressModels.Update(address);
            }
        }
        var result = await context.SaveChangesAsync(cancellationToken);
        return request.Id;

    }
}

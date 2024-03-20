using ApplicantPortal.Application.Common.Dtos;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ApplicantPortal.Infrastructure.Identity;

public class IdentityService(IApplicationDbContext context, UserManager<ApplicationUser> userManager,
    IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService, IPasswordHasher<ApplicationUser> passwordHasher) : IIdentityService
{
    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await userManager.Users.FirstAsync(u => u.Id == userId);
        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser { UserName = userName, Email = userName, };
        var result = await userManager.CreateAsync(user, password);
        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await userClaimsPrincipalFactory.CreateAsync(user);

        var result = await authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    private async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<UserDto> GetApplicationUserDetails(string? userId, CancellationToken cancellationToken)
    {
        // now lets generate application number give the application and update his status as started
        /*var FormNo = await _applicantRepository.GetFormNo();
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
        var calender = await _applicantRepository.GetConfiguration();
        if (user != null)
        {
            user.FormNo = calender?.Year + FormNo;
            user.Started = true;
            if (user.PictureUploaded == false)
            {
                await _userManager.UpdateAsync(user);
                await _applicantRepository.UpdateFormNo(cancellationToken);
            }
            else if (user.Admitted)
            {
                // put admission letter and fees info here
            }
        }*/
        var userdetails = await userManager.Users.Select(b =>
            new UserDto()
            {
                Id = b.Id,
                UserName = b.UserName,
                FormCompleted = b.FormCompleted,
                Finalized = b.Finalized,
                SoldBy = b.SoldBy,
                Branch = b.Branch,
                Started = b.Started,
                Year = b.Year,
                Pin = b.Pin,
                PictureUploaded = b.PictureUploaded,
                FormNo = b.FormNo,
                FullName = b.FullName,
                ResultUploaded = b.ResultUploaded,
                Admitted = b.Admitted,
                LastLogin = b.LastLogin,
                Type = b.VoucherType,
                Category = b.Category,
            }).FirstOrDefaultAsync(a => a.Id == userId, cancellationToken: cancellationToken);
        return userdetails ?? new UserDto();


        //  var userdetails = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == userId, cancellationToken: cancellationToken);

        // return      _mapper.Map<UserDto>(userdetails);
    }


    public  async Task<string> GetPin()
    {
        const string str = "2F934678ABCDGHJKLMNPRSTUVWXY";
        var shuffled = Shuffle(str);
        var vcode = shuffled.Result[..9];
        return await Task.FromResult(vcode.ToUpper());
    }

    public  async Task<string> GetSerial()
    {
        const string str = "ABCDEFGHJKLMNPRSTUVWXYZ2346789";
        var shuffled = Shuffle(str);
        var vcode = shuffled.Result[..4];
        var real = vcode.ToUpper();
        var data = "TTU" + (DateTime.Now.Year).ToString().TakeLast(4) + real;
        return await Task.FromResult(data);
    }

    public async Task<string>  Shuffle(string str)
    {
        Random num = new Random();
        string rand = new string(str.ToCharArray().OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
      return await  Task.FromResult(rand);
    }

    public async Task<Result> GenerateVoucher(int? quantity, ApplicationType type, string? owner,
        CancellationToken cancellationToken)
    {
        for (int a = 0; a < quantity; a++)
        {
            var pin = await GetPin();
            var serial = await GetSerial();
            //ApplicationUser user = new();
            ApplicationUser applicationUser = new();
            Guid guid = Guid.NewGuid();
            applicationUser.Id = guid.ToString();
            applicationUser.UserName = serial + a;
            applicationUser.Email = serial + a + "@ttu.edu.gh";
            applicationUser.NormalizedUserName = serial + a;
            applicationUser.Year = (DateTime.Now.Year).ToString();
            applicationUser.Pin = pin;
            applicationUser.SoldBy = owner?.ToUpper();
            applicationUser.Sold = false;
            applicationUser.Started = false;
            applicationUser.VoucherType = type;
            applicationUser.EmailConfirmed = true;
            applicationUser.Category = "Undergraduate";
            applicationUser.ForeignApplicant = false;
            applicationUser.NormalizedEmail = serial + "@ttu.edu.gh" + a;
            var hashedPassword = passwordHasher.HashPassword(applicationUser, pin);
            applicationUser.SecurityStamp = Guid.NewGuid().ToString();
            applicationUser.PasswordHash = hashedPassword;
            Console.Write("User created successfully in memory");
            var result = userManager.CreateAsync(applicationUser).Result;
            Console.Write("User created successfully in memory");
            if (!result.Succeeded)
            {
                continue;
            }

            await context.SaveChangesAsync(cancellationToken);
            Console.WriteLine("User created successfully in DB");
        }

        return Result.Success();
    }
    public async Task UpdateApplicationPictureStatus(string? userId, ICollection<FileDto> photo, CancellationToken cancellationToken)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.PictureUploaded = true;
            await userManager.UpdateAsync(user);
            
        }
    }
    public async Task<bool> ChangeApplicantFormType(string? userId, string? formType)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return false;
        }

        user.Category = formType;
        await userManager.UpdateAsync(user);
        return true;
    }
    public async  Task<Result> GenerateVoucher(int? quantity, string? type, string? owner, CancellationToken cancellationToken){
        for (int a = 0; a < quantity; a++)
        {


            var Pin = GetPin();
            var Serial = GetSerial();
            //ApplicationUser user = new();
            ApplicationUser applicationUser = new();
            Guid guid = Guid.NewGuid();
            applicationUser.Id = guid.ToString();
            applicationUser.UserName = Serial.Result+a;
            applicationUser.Email = Serial.Result+a+"@ttu.edu.gh";
            applicationUser.NormalizedUserName = Serial.Result+a;
            applicationUser.Year = (DateTime.Now.Year).ToString();
            applicationUser.Pin = Pin.Result;
            applicationUser.SoldBy = owner!.ToUpper();
            applicationUser.Sold = false;
            applicationUser.Started = false;
            applicationUser.Category = type!.ToUpper();
            applicationUser.EmailConfirmed = true;
            applicationUser.Category ="Undergraduate";
            applicationUser.ForeignApplicant = false;
            applicationUser.NormalizedEmail = Serial + "@ttu.edu.gh"+a;
            var hasedPassword = passwordHasher.HashPassword(applicationUser, Pin.Result);
            applicationUser.SecurityStamp = Guid.NewGuid().ToString();
            applicationUser.PasswordHash = hasedPassword;
            Console.Write("User created successfully in memory");
  
            var result = userManager.CreateAsync(applicationUser).Result;
            Console.Write("User created successfully in memory");
            if (!result.Succeeded)
            {
                continue;
            }

            await  context.SaveChangesAsync(cancellationToken);
            Console.WriteLine("User created successfully in DB");

        }
      
        return     Result.Success();
    }
     
   
    public async Task Finalized(string userId)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.Finalized = true;
            user.FormCompleted = true;
            await userManager.UpdateAsync(user);
        }
    }
    
}

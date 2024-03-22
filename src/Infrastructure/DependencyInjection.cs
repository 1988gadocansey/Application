using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Constants;
using ApplicantPortal.Infrastructure.Data;
using ApplicantPortal.Infrastructure.Data.Interceptors;
using ApplicantPortal.Infrastructure.Data.Repositories;
using ApplicantPortal.Infrastructure.Identity;
using ApplicantPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using  ApplicantPortal.Infrastructure.Mails;
using ApplicantPortal.Infrastructure.SMS;
namespace ApplicantPortal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
            options.EnableDetailedErrors();

        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IApplicantRepository, ApplicantService>();
        services.AddTransient<IPhotoUploadService, PhotoUploadService>();
        services.AddTransient<IEmailSender, EmailService>();
        services.AddTransient<ISmsSender, SmsService>();
        services.AddTransient<IDocumentUploadService, DocumentUploadService>();
        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));
        services.AddTransient<IApplicantRepository, ApplicantRepository>();
        return services;
    }
}

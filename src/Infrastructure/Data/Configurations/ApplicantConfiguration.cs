using ApplicantPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicantPortal.Domain.ValueObjects;
using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Infrastructure.Data.Configurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<ApplicantModel>
{
    public void Configure(EntityTypeBuilder<ApplicantModel> builder)
    {
        /*
         If an Entity contains a collection of Value Objects, we can use the OwnsMany method

         modelBuilder.Entity<Person>().OwnsMany(p => p.PhoneNumbers);
         builder.Entity<Person>().HasKey(x => x.Id);
        builder.Entity<Person>().OwnsOne(p => p.PhoneNumber);

        // Or:
        // modelBuilder.Entity<Person>().OwnsOne(typeof(PhoneNumber),
        //    "PhoneNumber");
        // in case PhoneNumber property is private.*/

        /*  builder.ToTable("ApplicantModel");
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasColumnName("Id")
             .ValueGeneratedNever(); */

        // we are using value object for key read Nick Chamberlain's blog post here: https://buildplease.com/pages/vo-ids/
        builder.ToTable("ApplicantModel");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id");


        // .ValueGeneratedOnAdd();

        builder.OwnsOne(x => x.ApplicantName, nameBuilder =>
        {
            nameBuilder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
            nameBuilder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
            nameBuilder.Property(p => p.Othernames).HasColumnName("Othernames");
        });

        builder.Navigation(e => e.ApplicantName).IsRequired();

        /*
         * Rename properties' columns because they'd otherwise be prefixed with 'PreviousName_'
         */
        builder.OwnsOne(x => x.PreviousName, nameBuilder =>
        {
            nameBuilder.Property(p => p.FirstName).HasColumnName("PreviousFirstName").IsRequired();
            nameBuilder.Property(p => p.LastName).HasColumnName("PreviousLastName").IsRequired();
            nameBuilder.Property(p => p.Othernames).HasColumnName("PreviousOthernames");
        });
        builder.OwnsOne(x => x.HallFeesPaid, nameBuilder =>
        {
            nameBuilder.Property(p => p.Amount).HasColumnName("HallFeesPaid").IsRequired();
            nameBuilder.Property(p => p.Currency).HasColumnName("HallFeesPaidCurrency");
        });
       

        builder.OwnsOne(x => x.FeesPaid, nameBuilder =>
        {
            nameBuilder.Property(p => p.Amount).HasColumnName("FeesPaid").IsRequired();
            nameBuilder.Property(p => p.Currency).HasColumnName("FeesPaidCurrency");
        });

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasConversion(email => email!.Value, value => new EmailAddress(value));
        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasConversion(phone => phone!.FullNumber(), value => new PhoneNumber(value,value))
            .IsRequired();
        builder.Property(x => x.AltPhone)
            .HasColumnName("AltPhone")
            .HasConversion(phone => phone!.FullNumber(), value => new PhoneNumber(value,value));
        builder.Property(x => x.GuardianPhone)
            .HasColumnName("GuardianPhone")
            .HasConversion(phone => phone!.FullNumber(), value => new PhoneNumber(value,value))
            .IsRequired();
        builder.Property(x => x.EmergencyContact)
            .HasColumnName("EmergencyContact")
            .HasConversion(phone => phone!.FullNumber(), value => new PhoneNumber(value,value))
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasColumnName("Gender")
            .IsRequired()
            .HasConversion<string>();
        
        

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.AdmissionType)
            .HasColumnName("AdmissionType")
            .HasConversion<string>();
        /*
                builder.Property(x => x.NationalIDType)
                    .HasColumnName("NationalIDType")
                    .IsRequired()
                    .HasConversion<string>(); */

        builder.OwnsOne(x => x.IdCard, nameBuilder =>
        {
            nameBuilder.Property(p => p.NationalIDNo).HasColumnName("NationalIDNo").IsRequired();
            nameBuilder.Property(p => p.NationalIDType).HasColumnName("NationalIDType").IsRequired().HasConversion<string>();;
        });
        /*   builder.HasOne(x => x.FirstChoice)
             .WithMany(x => x.Applicant)
             .HasForeignKey(x => x.FirstChoiceId);

          builder.HasOne(x => x.SecondChoice)
        .WithMany(x => x.Applicant)
        .HasForeignKey(x => x.SecondChoiceId);

          builder.HasOne(x => x.ThirdChoice)
          .WithMany(x => x.Applicant)
          .HasForeignKey(x => x.ThirdChoiceId); */

        builder.Property(x => x.MaritalStatus)
            .HasColumnName("MaritalStatus")
            .HasConversion(
                v => v.ToString(),
                v => (MaritalStatus)Enum.Parse(typeof(MaritalStatus), v!));
        /*
         builder.Property(x => x.Title)
              .HasColumnName("Title")
               .HasConversion(
        v => v.ToString(),
        v => (Title)Enum.Parse(typeof(Title), v)); */
        //  .IsRequired();

        // if you want to store all value objects in one column as json


        /*   builder.Property(user => user.Addresses)
              .HasConversion(
              a => (string)JsonConvert.SerializeObject(a),
              a => JsonConvert.DeserializeObject<List<Address>>(a));
          /*builder.HasData(Data.GetData<User>());*/


        builder.Property(x => x.ApplicationNumber)
            .HasColumnName("ApplicationNumber")
            .HasConversion(applicantNumber => applicantNumber!.ApplicantNumber, value =>  ApplicationNumber.Create(value))
            .IsRequired();

        //builder.HasMany<ApplicantModel>(applicant => applicant.Phone);

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasDefaultValue(ApplicationStatus.Applicant)
            .HasConversion(
                v => v.ToString(),
                v => (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), v!));


        builder.Property(x => x.EntryMode)
            .HasColumnName("EntryMode")
            .HasConversion<string>();
        builder.Property(x => x.FirstQualification)
            .HasColumnName("FirstQualification")
            .HasConversion<string>();

        builder.Property(x => x.SecondQualification)
            .HasColumnName("SecondQualification")
            .HasConversion<string>();

        builder.Property(x => x.FirstQualification)
            .HasColumnName("FirstQualification")
            .HasConversion<string>();
    }
}

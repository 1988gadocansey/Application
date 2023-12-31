using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandValidator : AbstractValidator<CreateBiodataRequest>
{
    private readonly IApplicationDbContext _context;

    public CreateBiodataCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
        RuleFor(v => v.Email)
            .EmailAddress().WithMessage("A valid email is required")
            .MaximumLength(200).WithMessage("Email must not exceed 100 characters.");


        RuleFor(v => v.NationalIdType.ToString())
            .NotEmpty().WithMessage("National Card is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            ;
        RuleFor(v => v.Gender)
            .NotEmpty().WithMessage("Gender is required.");

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(v => v.Hometown)
            .NotEmpty().WithMessage("Hometown is required.");

        RuleFor(v => v.NationalIdNo)
            .NotEmpty().WithMessage("ID Card Number is required.");

        RuleFor(v => v.NationalIdType)
            .NotEmpty().WithMessage("ID Card Type is required.");

        RuleFor(v => v.NationalIdNo)
            .NotEmpty().WithMessage("National ID No is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueNationalIDNo).WithMessage("The specified ID already exists.");
    }

    public async Task<bool> BeUniqueNationalIDNo(string NationalIDNo, CancellationToken cancellationToken)
    {
        return await _context.ApplicantModels
            .AllAsync(l => l.IdCard!.NationalIDNo != NationalIDNo, cancellationToken);
    }
}

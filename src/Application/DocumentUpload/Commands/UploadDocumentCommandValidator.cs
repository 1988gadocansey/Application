using ApplicantPortal.Application.Common.Dtos;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace ApplicantPortal.Application.DocumentUpload.Commands
{
    public class UploadDocumentCommandValidator : AbstractValidator<UploadDocumentRequest>
    {
        /*public UploadDocumentCommandValidator()
        {
            RuleForEach(v => v.Files)
                .NotEmpty()
                .WithMessage("File cannot be empty")
                .Must(IsValidContentType)
                .WithMessage("Invalid file type. Only '.pdf' and '.docx' files are allowed");
        }

        private static bool IsValidContentType(IEnumerable<FileDto> files)
        {
            var validContentTypes = new[] { "application/pdf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };

            return files.All(file => validContentTypes.Contains(file.ContentType));
        }*/
        
    }
}

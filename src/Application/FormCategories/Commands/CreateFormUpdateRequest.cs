using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Enums;

namespace ApplicantPortal.Application.FormCategories.Commands;

public abstract class CreateFormUpdateRequest:IRequest<bool>
{
        public ApplicationType FormType { get; set; }
}

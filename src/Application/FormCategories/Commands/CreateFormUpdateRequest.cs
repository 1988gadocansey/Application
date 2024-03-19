using ApplicantPortal.Application.Common.Interfaces;

namespace ApplicantPortal.Application.FormCategories.Commands;

public abstract class CreateFormUpdateRequest:IRequest<bool>
{
        public ApplicationType FormType { get; set; }
}

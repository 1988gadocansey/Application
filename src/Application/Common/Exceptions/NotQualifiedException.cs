namespace ApplicantPortal.Application.Common.Exceptions;

public class NotQualifiedException:Exception
{
    public NotQualifiedException():base("Not qualified for admissions.")
    {
        
    }
}

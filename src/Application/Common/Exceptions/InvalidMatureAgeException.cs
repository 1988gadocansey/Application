namespace ApplicantPortal.Application.Common.Exceptions;

public class InvalidMatureAgeException : Exception
{
    InvalidMatureAgeException() : base("You are not qualified for Matured Entrance.")
    {
        
    }
}

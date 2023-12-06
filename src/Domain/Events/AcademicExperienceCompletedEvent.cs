namespace ApplicantPortal.Domain.Events;

public class AcademicExperienceCompletedEvent
{
    public AcademicExperienceCompletedEvent(AcademicExperienceModel academicExperience)
    {
        academicModel = academicExperience;
    }

    public AcademicExperienceModel academicModel { get; }

}

public class AcademicExperienceDeletedEvent
{
    public AcademicExperienceDeletedEvent(AcademicExperienceModel academicExperience)
    {
        academicModel = academicExperience;
    }

    public AcademicExperienceModel academicModel { get; }
    
}
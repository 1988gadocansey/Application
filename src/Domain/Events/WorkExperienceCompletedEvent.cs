namespace ApplicantPortal.Domain.Events;

public class WorkExperienceCompletedEvent : BaseEvent
{
    public WorkExperienceCompletedEvent(WorkingExperienceModel workingExperience)
    {
        WorkModel = workingExperience;
    }

    public WorkingExperienceModel WorkModel { get; }
}

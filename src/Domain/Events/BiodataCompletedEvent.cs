namespace ApplicantPortal.Domain.Events;

public class BiodataCompletedEvent : BaseEvent
{
    public BiodataCompletedEvent(ApplicantModel applicantModel)
    {
        applicant = applicantModel;
    }

    public ApplicantModel applicant { get; }
}

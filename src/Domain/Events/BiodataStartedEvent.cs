namespace ApplicantPortal.Domain.Events;

public class BiodataStartedEvent : BaseEvent
{
    public BiodataStartedEvent(ApplicantModel applicantModel)
    {

        applicant = applicantModel;
    }

    public ApplicantModel applicant { get; }
}

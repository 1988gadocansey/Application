namespace ApplicantPortal.Domain.Events;

public class ResultDeletedEvent : BaseEvent
{
    public ResultDeletedEvent(ApplicantModel applicantModel)
    {
        applicant = applicantModel;
    }

    public ApplicantModel applicant { get; }
}

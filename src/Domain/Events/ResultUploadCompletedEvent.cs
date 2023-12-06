namespace ApplicantPortal.Domain.Events;

public class ResultUploadCompletedEvent : BaseEvent
{
    public ResultUploadCompletedEvent(ApplicantModel applicantModel)
    {
        applicant = applicantModel;
    }

    public ApplicantModel applicant { get; }
}

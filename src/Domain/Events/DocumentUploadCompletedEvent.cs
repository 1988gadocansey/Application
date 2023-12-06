namespace ApplicantPortal.Domain.Events;

public class DocumentUploadCompletedEvent : BaseEvent
{
    public DocumentUploadCompletedEvent(ApplicantModel applicantModel)
    {
        applicant = applicantModel;
    }

    public ApplicantModel applicant { get; }
}

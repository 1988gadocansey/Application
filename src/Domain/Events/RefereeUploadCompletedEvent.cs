public class RefereeUploadCompletedEvent: BaseEvent
{
     public RefereeUploadCompletedEvent(ApplicantModel applicantModel)
    {
        applicant = applicantModel;
    }

    public ApplicantModel applicant { get; }
}
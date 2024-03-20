using ApplicantPortal.Domain.Events;
using Microsoft.Extensions.Logging;

namespace ApplicantPortal.Application.Biodata.EventHandlers;

public class ApplicationCompletedEvent(ILogger<BioDataCreatedEventHandler> logger)
    : INotificationHandler<BiodataCompletedEvent>
{
    public Task Handle(BiodataCompletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Application portal  Form completed : {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

using ApplicantPortal.Domain.Events;
using Microsoft.Extensions.Logging;

namespace ApplicantPortal.Application.Biodata.EventHandlers;

public class BioDataCreatedEventHandler(ILogger<BioDataCreatedEventHandler> logger)
    : INotificationHandler<BiodataStartedEvent>
{
    public Task Handle(BiodataStartedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("OnlineApplicationSystem Biodata started : {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }


}

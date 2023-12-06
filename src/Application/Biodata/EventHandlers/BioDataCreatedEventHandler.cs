using MediatR;
using Microsoft.Extensions.Logging;
using ApplicantPortal.Domain.Events;
namespace ApplicantPortal.Domain.Events;

public class BioDataCreatedEventHandler : INotificationHandler<BiodataStartedEvent>
{
    private readonly ILogger<BioDataCreatedEventHandler> _logger;

    public BioDataCreatedEventHandler(ILogger<BioDataCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BiodataStartedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ApplicantPortal Biodata started : {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }


}

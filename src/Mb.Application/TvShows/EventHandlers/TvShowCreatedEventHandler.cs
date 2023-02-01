using Mb.Domain.Events.TvShow;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mb.Application.TvShows.EventHandlers;

public class TvShowCreatedEventHandler : INotificationHandler<TvShowAddedEvent>
{
    private readonly ILogger<TvShowCreatedEventHandler> _logger;

    public TvShowCreatedEventHandler(ILogger<TvShowCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TvShowAddedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MovieBase Mb.Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
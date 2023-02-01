using Mb.Domain.Events.Movie;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mb.Application.Movies.EventHandlers;

public class MovieReleasedEventHandler : INotificationHandler<MovieReleasedEvent>
{
    private readonly ILogger<MovieReleasedEventHandler> _logger;

    public MovieReleasedEventHandler(ILogger<MovieReleasedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(MovieReleasedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MovieBase Mb.Domain Event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
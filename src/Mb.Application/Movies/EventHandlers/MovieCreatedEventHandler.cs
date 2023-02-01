using Mb.Domain.Events.Movie;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mb.Application.Movies.EventHandlers;

public class MovieCreatedEventHandler : INotificationHandler<MovieAddedEvent>
{
    private readonly ILogger<MovieCreatedEventHandler> _logger;

    public MovieCreatedEventHandler(ILogger<MovieCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(MovieAddedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MovieBase Mb.Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
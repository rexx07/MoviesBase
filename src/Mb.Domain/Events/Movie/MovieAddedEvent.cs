using Mb.Domain.Common;

namespace Mb.Domain.Events.Movie;

public class MovieAddedEvent : BaseEvent
{
    public MovieAddedEvent(Entities.Movie movie)
    {
        Movie = movie;
    }

    public Entities.Movie Movie { get; }
}
using Mb.Domain.Common;

namespace Mb.Domain.Events.Movie;

public class MovieReleasedEvent : BaseEvent
{
    public MovieReleasedEvent(Entities.Movie movie)
    {
        Movie = movie;
    }

    public Entities.Movie Movie { get; set; }
}
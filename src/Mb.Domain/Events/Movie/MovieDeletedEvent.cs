using Mb.Domain.Common;

namespace Mb.Domain.Events.Movie;

public class MovieDeletedEvent : BaseEvent
{
    public MovieDeletedEvent(Entities.Movie movie)
    {
        Movie = movie;
    }

    public Entities.Movie Movie { get; set; }
}
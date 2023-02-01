using Mb.Domain.Common;

namespace Mb.Domain.Events.TvShow;

public class TvShowReleasedEvent : BaseEvent
{
    public TvShowReleasedEvent(Entities.TvShow tvShow)
    {
        TvShow = tvShow;
    }

    public Entities.TvShow TvShow { get; set; }
}
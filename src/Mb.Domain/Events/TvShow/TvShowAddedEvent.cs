using Mb.Domain.Common;

namespace Mb.Domain.Events.TvShow;

public class TvShowAddedEvent : BaseEvent
{
    public TvShowAddedEvent(Entities.TvShow tvShow)
    {
        TvShow = tvShow;
    }

    public Entities.TvShow TvShow { get; set; }
}
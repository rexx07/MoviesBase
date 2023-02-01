using Mb.Domain.Common;

namespace Mb.Domain.Events.TvShow;

public class TvShowDeletedEvent : BaseEvent
{
    public TvShowDeletedEvent(Entities.TvShow tvShow)
    {
        TvShow = tvShow;
    }

    public Entities.TvShow TvShow { get; set; }
}
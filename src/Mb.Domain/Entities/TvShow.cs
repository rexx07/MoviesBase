using Mb.Domain.Common;
using Mb.Domain.Events.TvShow;

namespace Mb.Domain.Entities;

public class TvShow : BaseAuditableEntity
{
    private bool _done;

    public bool Done
    {
        get => _done;
        set
        {
            if (value && _done == false)
                AddDomainEvent(new TvShowAddedEvent(this));
            _done = value;
        }
    }

    public Guid ListId { get; set; }
    public string OriginalName { get; set; }
    public List<Guid> GenreIds { get; set; }
    public string Name { get; set; }
    public string TagLine { get; set; }
    public float Popularity { get; set; }
    public List<string> OriginCountries { get; set; }
    public int VoteCount { get; set; }
    public DateOnly FirstAirDate { get; set; }
    public string BackdropPath { get; set; }
    public string OriginalLanguage { get; set; }
    public float VoteAverage { get; set; }
    public string Overview { get; set; }
    public string PosterPath { get; set; }
    public string HomePageUrl { get; set; }
    public int NumberOfEpisodes { get; set; }
    public int NumberOfSeasons { get; set; }
}
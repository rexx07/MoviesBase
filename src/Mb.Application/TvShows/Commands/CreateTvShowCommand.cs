using Mb.Application.Common.Interfaces;
using Mb.Domain.Entities;
using Mb.Domain.Events.TvShow;
using MediatR;

namespace Mb.Application.TvShows.Commands;

public class CreateTvShowCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
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

public class CreateTvShowCommandHandler : IRequestHandler<CreateTvShowCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTvShowCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTvShowCommand request, CancellationToken cancellationToken)
    {
        var entity = new TvShow
        {
            OriginalName = request.OriginalName,
            GenreIds = request.GenreIds,
            Name = request.Name,
            TagLine = request.TagLine,
            Popularity = request.Popularity,
            OriginCountries = request.OriginCountries,
            VoteCount = request.VoteCount,
            FirstAirDate = request.FirstAirDate,
            BackdropPath = request.BackdropPath,
            OriginalLanguage = request.OriginalLanguage,
            VoteAverage = request.VoteAverage,
            Overview = request.Overview,
            PosterPath = request.PosterPath,
            HomePageUrl = request.HomePageUrl,
            NumberOfEpisodes = request.NumberOfEpisodes,
            NumberOfSeasons = request.NumberOfSeasons
        };

        await _context.TvShows.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new TvShowAddedEvent(entity));

        return entity.Id;
    }
}
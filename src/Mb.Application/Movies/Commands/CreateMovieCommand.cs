using FluentValidation;
using Mb.Application.Common.Interfaces;
using Mb.Domain.Entities;
using Mb.Domain.Enums;
using Mb.Domain.Events.Movie;
using MediatR;

namespace Mb.Application.Movies.Commands;

public class CreateMovieCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public bool Adult { get; set; }
    public string? BackdropPath { get; set; }
    public List<Guid> GenreIds { get; set; }
    public string? HomePageUrl { get; set; }
    public string OriginalLanguage { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public float Popularity { get; set; }
    public string PosterPath { get; set; }
    public List<string> ProductionCompanies { get; set; }
    public List<string> ProductionCountries { get; set; }
    public double ProductionCost { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public double Revenue { get; set; }
    public int Runtime { get; set; }
    public List<string> SpokenLanguages { get; set; }
    public Status Status { get; set; }
    public string TagLine { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }
    public float VoteAverage { get; set; }
    public float VoteCount { get; set; }
}

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = new Movie
        {
            Title = request.Title,
            Adult = request.Adult,
            BackdropPath = request.BackdropPath,
            GenreIds = request.GenreIds,
            HomePageUrl = request.HomePageUrl,
            OriginalLanguage = request.OriginalLanguage,
            OriginalTitle = request.OriginalTitle,
            Overview = request.Overview,
            Popularity = request.Popularity,
            PosterPath = request.PosterPath,
            ProductionCompanies = request.ProductionCompanies,
            ProductionCountries = request.ProductionCountries,
            ProductionCost = request.ProductionCost,
            Revenue = request.Revenue,
            Runtime = request.Runtime,
            ReleaseDate = request.ReleaseDate,
            SpokenLanguages = request.SpokenLanguages,
            Status = request.Status,
            TagLine = request.TagLine,
            Video = request.Video,
            VoteCount = request.VoteCount,
            VoteAverage = request.VoteAverage
        };

        await _context.Movies.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new MovieAddedEvent(entity));

        return entity.Id;
    }
}

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(m => m.Title)
            .MaximumLength(250).WithMessage("Title must not exceed 100 characters.")
            .NotEmpty().WithMessage("Please insert movie title.");
        RuleFor(m => m.PosterPath)
            .NotEmpty().WithMessage("Insert Movie Cover");
    }
}
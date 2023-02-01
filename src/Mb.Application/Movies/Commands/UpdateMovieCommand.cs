using AutoMapper;
using FluentValidation;
using Mb.Application.Common.Exceptions;
using Mb.Application.Common.Interfaces;
using Mb.Domain.Entities;
using Mb.Domain.Enums;
using MediatR;

namespace Mb.Application.Movies.Commands;

public record UpdateMovieCommand : IRequest
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

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    public readonly IApplicationDbContext _context;
    public readonly IMapper _mapper;

    public UpdateMovieCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Movie), request.Id);

        entity.Title = request.Title;
        entity.Adult = request.Adult;
        entity.BackdropPath = request.BackdropPath;
        entity.GenreIds = request.GenreIds;
        entity.HomePageUrl = request.HomePageUrl;
        entity.OriginalLanguage = request.OriginalLanguage;
        entity.OriginalTitle = request.OriginalTitle;
        entity.Overview = request.Overview;
        entity.Popularity = request.Popularity;
        entity.PosterPath = request.PosterPath;
        entity.ProductionCompanies = request.ProductionCompanies;
        entity.ProductionCountries = request.ProductionCountries;
        entity.ProductionCost = request.ProductionCost;
        entity.Revenue = request.Revenue;
        entity.Runtime = request.Runtime;
        entity.ReleaseDate = request.ReleaseDate;
        entity.SpokenLanguages = request.SpokenLanguages;
        entity.Status = request.Status;
        entity.TagLine = request.TagLine;
        entity.Video = request.Video;
        entity.VoteCount = request.VoteCount;
        entity.VoteAverage = request.VoteAverage;


        _context.Movies.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMovieCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(m => m.Title)
            .MaximumLength(250)
            .NotEmpty().WithMessage("Please insert movie title.");
    }
}
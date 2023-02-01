using Mb.Domain.Entities;
using Mb.Domain.Enums;

namespace Mb.Application.Movies.Models;

public class MovieDto
{
    public bool Adult { get; set; }
    public string? BackdropPath { get; set; }
    public List<Genre> Genres { get; set; }
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
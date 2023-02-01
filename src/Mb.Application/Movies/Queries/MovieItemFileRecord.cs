using Mb.Application.Common.Mappings;
using Mb.Domain.Entities;

namespace Mb.Application.Movies.Queries;

public class MovieItemFileRecord : IMapFrom<Movie>
{
    public string? Title { get; set; }
    public bool Done { get; set; }
}
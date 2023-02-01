using Mb.Application.Common.Mappings;
using Mb.Domain.Entities;

namespace Mb.Application.TvShows.Queries;

public class TvShowItemFileRecord : IMapFrom<TvShow>
{
    public string? Title { get; set; }
    public bool Done { get; set; }
}
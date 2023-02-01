using Mb.Application.Common.Mappings;
using Mb.Domain.Entities;

namespace Mb.Application.Common.Models;

public class LookupDto : IMapFrom<Movie>, IMapFrom<TvShow>, IMapFrom<Genre>
{
    public int Id { get; set; }
    public string? Title { get; set; }
}
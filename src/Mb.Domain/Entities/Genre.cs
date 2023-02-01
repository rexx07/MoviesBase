using Mb.Domain.Common;

namespace Mb.Domain.Entities;

public class Genre : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Guid> MovieIds { get; set; }
    public List<Guid> TvShowIds { get; set; }
}
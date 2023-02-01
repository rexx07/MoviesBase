using Mb.Domain.Common;

namespace Mb.Domain.Entities;

public class Member : BaseAuditableEntity
{
    public string FName { get; set; }
    public string MName { get; set; }
    public string LName { get; set; }
    public string CountryOfOrigin { get; set; }
    public DateOnly DOB { get; set; }
    public DateOnly CareerStart { get; set; }
    public DateOnly? CareerEnd { get; set; }
    public List<Guid> MovieIds { get; set; }
    public List<Guid> TvShowIds { get; set; }
    public bool IsCast { get; set; }
}
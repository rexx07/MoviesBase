using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mb.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    DbSet<Genre> Genres { get; }
    DbSet<TvShow> TvShows { get; }
    DbSet<Member> Members { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
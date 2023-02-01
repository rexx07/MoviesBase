using Mb.Application.Movies.Queries;
using Mb.Application.TvShows.Queries;

namespace Mb.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildMovieItemsFile(IEnumerable<MovieItemFileRecord> movies);
    byte[] BuildTvShowItemsFile(IEnumerable<TvShowItemFileRecord> tvShows);
}
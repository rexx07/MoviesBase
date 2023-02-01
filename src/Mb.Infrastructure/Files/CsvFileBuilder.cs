using System.Globalization;
using System.Text;
using CsvHelper;
using Mb.Application.Common.Interfaces;
using Mb.Application.Movies.Queries;
using Mb.Application.TvShows.Queries;
using Mb.Infrastructure.Files.Maps;

namespace Mb.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildMovieItemsFile(IEnumerable<MovieItemFileRecord> movies)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<MovieMap>();
            csvWriter.WriteRecord(movies);
        }

        return memoryStream.ToArray();
    }

    public byte[] BuildTvShowItemsFile(IEnumerable<TvShowItemFileRecord> tvShows)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TvShowMap>();
            csvWriter.WriteRecord(tvShows);
        }

        return memoryStream.ToArray();
    }
}
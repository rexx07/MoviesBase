using System.Globalization;
using CsvHelper.Configuration;
using Mb.Application.TvShows.Queries;

namespace Mb.Infrastructure.Files.Maps;

public sealed class TvShowMap : ClassMap<TvShowItemFileRecord>
{
    public TvShowMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
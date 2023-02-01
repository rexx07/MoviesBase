using System.Globalization;
using CsvHelper.Configuration;
using Mb.Application.Movies.Queries;

namespace Mb.Infrastructure.Files.Maps;

public sealed class MovieMap : ClassMap<MovieItemFileRecord>
{
    public MovieMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
using Mb.Domain.Entities;
using Mb.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Mb.Infrastructure.Persistence.Configurations;

public class TvShowConfig<T> : IEntityTypeConfiguration<TvShow>
{
    private readonly ValueComparer<List<T>> _comparer = new ModelValueComparer<T>()._comparer;

    public void Configure(EntityTypeBuilder<TvShow> builder)
    {
        builder.ToTable("Tv Shows");

        builder.Property(t => t.GenreIds)
            .HasConversion(new ValueConverter<List<T>, string>(
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                // Convert to List<string> for use.
                v => JsonConvert.DeserializeObject<List<T>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);

        builder.Property(t => t.OriginCountries)
            .HasConversion(new ValueConverter<List<T>, string>(
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                v => JsonConvert.DeserializeObject<List<T>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);
    }
}
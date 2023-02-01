using Mb.Domain.Entities;
using Mb.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Mb.Infrastructure.Persistence.Configurations;

public class MovieConfig<T> : IEntityTypeConfiguration<Movie>
{
    private readonly ValueComparer<List<T>> _comparer = new ModelValueComparer<T>()._comparer;

    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.Property(m => m.Title)
            .HasColumnName("Movie Title")
            .IsRequired();

        builder.Property(m => m.Overview)
            .HasColumnName("Movie Description")
            .IsRequired();

        builder.Property(m => m.ReleaseDate)
            .HasColumnName("Movie Year")
            .IsRequired();

        builder.Property(m => m.VoteAverage)
            .HasColumnName("Movie Rating")
            .IsRequired();

        builder.Property(m => m.PosterPath)
            .HasColumnName("Movie Image")
            .IsRequired();

        builder.Property(m => m.BackdropPath)
            .HasColumnName("Movie Image Cover");

        // Configure the value converter for the Movie 
        builder
            .Property(m => m.ProductionCompanies)
            .HasConversion(new ValueConverter<List<T>, string>(
                // Convert to string for persistence
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                // Convert to List<string> for use.
                v => JsonConvert.DeserializeObject<List<T>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);

        builder
            .Property(m => m.ProductionCountries)
            .HasConversion(new ValueConverter<List<string>, string>(
                // Convert to string for persistence
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                // Convert to List<string> for use.
                v => JsonConvert.DeserializeObject<List<string>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);

        builder
            .Property(m => m.GenreIds)
            .HasConversion(new ValueConverter<List<Guid>, string>(
                // Convert to string for persistence
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                // Convert to List<string> for use.
                v => JsonConvert.DeserializeObject<List<Guid>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);

        builder
            .Property(m => m.SpokenLanguages)
            .HasConversion(new ValueConverter<List<string>, string>(
                // Convert to string for persistence
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                // Convert to List<string> for use.
                v => JsonConvert.DeserializeObject<List<string>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);
    }
}
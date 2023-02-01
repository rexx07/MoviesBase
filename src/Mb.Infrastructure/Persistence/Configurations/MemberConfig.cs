using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Mb.Infrastructure.Persistence.Configurations;

public class MemberConfig<T> : IEntityTypeConfiguration<Member>
{
    private readonly ValueComparer<List<T>> _comparer;

    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Movie/Cast Members");

        builder
            .Property(m => m.TvShowIds)
            .HasConversion(new ValueConverter<List<T>, string>(
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                v => JsonConvert.DeserializeObject<List<T>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);

        builder
            .Property(m => m.MovieIds)
            .HasConversion(new ValueConverter<List<T>, string>(
                v => JsonConvert.SerializeObject(v, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                v => JsonConvert.DeserializeObject<List<T>>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })!))
            .Metadata
            .SetValueComparer(_comparer);
    }
}
using Films.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.Infrastructure.Database.TypeConfigurations;

public class FilmEntityTypeConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Link).HasMaxLength(3999);
        builder.Property(x => x.Review).HasMaxLength(1000);
    }
}
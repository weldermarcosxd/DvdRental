using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class FilmConfigurator : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> entity)
        {
            entity.ToTable("film");

            entity.HasIndex(e => e.Fulltext)
                .HasName("film_fulltext_idx")
                .HasMethod("gist");

            entity.HasIndex(e => e.LanguageId)
                .HasName("idx_fk_language_id");

            entity.HasIndex(e => e.Title)
                .HasName("idx_title");

            entity.Property(e => e.FilmId).HasColumnName("film_id");

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Fulltext)
                .IsRequired()
                .HasColumnName("fulltext");

            entity.Property(e => e.LanguageId).HasColumnName("language_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Length).HasColumnName("length");

            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");

            entity.Property(e => e.RentalDuration)
                .HasColumnName("rental_duration")
                .HasDefaultValueSql("3");

            entity.Property(e => e.RentalRate)
                .HasColumnName("rental_rate")
                .HasColumnType("numeric(4,2)")
                .HasDefaultValueSql("4.99");

            entity.Property(e => e.ReplacementCost)
                .HasColumnName("replacement_cost")
                .HasColumnType("numeric(5,2)")
                .HasDefaultValueSql("19.99");

            entity.Property(e => e.SpecialFeatures).HasColumnName("special_features");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(255);

            entity.HasOne(d => d.Language)
                .WithMany(p => p.Film)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("film_language_id_fkey");
        }
    }
}

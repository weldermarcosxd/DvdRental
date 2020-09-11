using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class FilmCategoryConfigurator : IEntityTypeConfiguration<FilmCategory>
    {
        public void Configure(EntityTypeBuilder<FilmCategory> entity)
        {
            entity.HasKey(e => new { e.FilmId, e.CategoryId })
                    .HasName("film_category_pkey");

            entity.ToTable("film_category");

            entity.Property(e => e.FilmId).HasColumnName("film_id");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.FilmCategory)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("film_category_category_id_fkey");

            entity.HasOne(d => d.Film)
                .WithMany(p => p.FilmCategory)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("film_category_film_id_fkey");
        }
    }
}

using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class FilmListConfigurator : IEntityTypeConfiguration<FilmList>
    {
        public void Configure(EntityTypeBuilder<FilmList> entity)
        {
            entity.HasNoKey();

            entity.ToTable("film_list");

            entity.Property(e => e.Actors).HasColumnName("actors");

            entity.Property(e => e.Category)
                .HasColumnName("category")
                .HasMaxLength(25);

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Fid).HasColumnName("fid");

            entity.Property(e => e.Length).HasColumnName("length");

            entity.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("numeric(4,2)");

            entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(255);
        }
    }
}

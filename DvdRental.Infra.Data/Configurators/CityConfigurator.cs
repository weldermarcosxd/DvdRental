using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class CityConfigurator : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.ToTable("city");

            entity.HasIndex(e => e.CountryId)
                .HasName("idx_fk_country_id");

            entity.Property(e => e.CityId).HasColumnName("city_id");

            entity.Property(e => e.City1)
                .IsRequired()
                .HasColumnName("city")
                .HasMaxLength(50);

            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.HasOne(d => d.Country)
                .WithMany(p => p.City)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_city");
        }
    }
}

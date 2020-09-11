using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class CountryConfigurator : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.ToTable("country");

            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.Property(e => e.Country1)
                .IsRequired()
                .HasColumnName("country")
                .HasMaxLength(50);

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");
        }
    }
}

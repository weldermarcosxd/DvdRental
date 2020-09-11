using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class AddressConfigurator : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("address");

            entity.HasIndex(e => e.CityId)
                .HasName("idx_fk_city_id");

            entity.Property(e => e.AddressId).HasColumnName("address_id");

            entity.Property(e => e.Address1)
                .IsRequired()
                .HasColumnName("address")
                .HasMaxLength(50);

            entity.Property(e => e.Address2)
                .HasColumnName("address2")
                .HasMaxLength(50);

            entity.Property(e => e.CityId).HasColumnName("city_id");

            entity.Property(e => e.District)
                .IsRequired()
                .HasColumnName("district")
                .HasMaxLength(20);

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasColumnName("phone")
                .HasMaxLength(20);

            entity.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasMaxLength(10);

            entity.HasOne(d => d.City)
                .WithMany(p => p.Address)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_address_city");
        }
    }
}

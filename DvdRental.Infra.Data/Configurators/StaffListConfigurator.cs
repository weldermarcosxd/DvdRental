using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class StaffListConfigurator : IEntityTypeConfiguration<StaffList>
    {
        public void Configure(EntityTypeBuilder<StaffList> entity)
        {
            entity.HasNoKey();

            entity.ToTable("staff_list");

            entity.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(50);

            entity.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(50);

            entity.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(50);

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name).HasColumnName("name");

            entity.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20);

            entity.Property(e => e.Sid).HasColumnName("sid");

            entity.Property(e => e.ZipCode)
                .HasColumnName("zip code")
                .HasMaxLength(10);
        }
    }
}

using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class StaffConfigurator : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> entity)
        {
            entity.ToTable("staff");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasColumnName("active")
                .HasDefaultValueSql("true");

            entity.Property(e => e.AddressId).HasColumnName("address_id");

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(50);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(45);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(45);

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(40);

            entity.Property(e => e.Picture).HasColumnName("picture");

            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasMaxLength(16);

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Staff)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_address_id_fkey");
        }
    }
}

using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class StoreConfigurator : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> entity)
        {
            entity.ToTable("store");

            entity.HasIndex(e => e.ManagerStaffId)
                .HasName("idx_unq_manager_staff_id")
                .IsUnique();

            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.Property(e => e.AddressId).HasColumnName("address_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.ManagerStaffId).HasColumnName("manager_staff_id");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Store)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("store_address_id_fkey");

            entity.HasOne(d => d.ManagerStaff)
                .WithOne(p => p.Store)
                .HasForeignKey<Store>(d => d.ManagerStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("store_manager_staff_id_fkey");
        }
    }
}

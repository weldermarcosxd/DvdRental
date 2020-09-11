using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class RentalConfigurator : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> entity)
        {
            entity.ToTable("rental");

            entity.HasIndex(e => e.InventoryId)
                .HasName("idx_fk_inventory_id");

            entity.HasIndex(e => new { e.RentalDate, e.InventoryId, e.CustomerId })
                .HasName("idx_unq_rental_rental_date_inventory_id_customer_id")
                .IsUnique();

            entity.Property(e => e.RentalId).HasColumnName("rental_id");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.RentalDate).HasColumnName("rental_date");

            entity.Property(e => e.ReturnDate).HasColumnName("return_date");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Rental)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_customer_id_fkey");

            entity.HasOne(d => d.Inventory)
                .WithMany(p => p.Rental)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_inventory_id_fkey");

            entity.HasOne(d => d.Staff)
                .WithMany(p => p.Rental)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_staff_id_key");
        }
    }
}

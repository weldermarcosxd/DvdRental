using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class PaymentConfigurator : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.ToTable("payment");

            entity.HasIndex(e => e.CustomerId)
                .HasName("idx_fk_customer_id");

            entity.HasIndex(e => e.RentalId)
                .HasName("idx_fk_rental_id");

            entity.HasIndex(e => e.StaffId)
                .HasName("idx_fk_staff_id");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("numeric(5,2)");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");

            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");

            entity.Property(e => e.RentalId).HasColumnName("rental_id");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Payment)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_customer_id_fkey");

            entity.HasOne(d => d.Rental)
                .WithMany(p => p.Payment)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_rental_id_fkey");

            entity.HasOne(d => d.Staff)
                .WithMany(p => p.Payment)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_staff_id_fkey");
        }
    }
}

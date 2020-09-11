using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class CustomerConfigurator : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("customer");

            entity.HasIndex(e => e.AddressId)
                .HasName("idx_fk_address_id");

            entity.HasIndex(e => e.LastName)
                .HasName("idx_last_name");

            entity.HasIndex(e => e.StoreId)
                .HasName("idx_fk_store_id");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");

            entity.Property(e => e.Active).HasColumnName("active");

            entity.Property(e => e.Activebool)
                .IsRequired()
                .HasColumnName("activebool")
                .HasDefaultValueSql("true");

            entity.Property(e => e.AddressId).HasColumnName("address_id");

            entity.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .HasColumnType("date")
                .HasDefaultValueSql("('now'::text)::date");

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

            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Customer)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_address_id_fkey");
        }
    }
}

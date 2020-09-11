using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class InventoryConfigurator : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> entity)
        {
            entity.ToTable("inventory");

            entity.HasIndex(e => new { e.StoreId, e.FilmId })
                .HasName("idx_store_id_film_id");

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

            entity.Property(e => e.FilmId).HasColumnName("film_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Film)
                .WithMany(p => p.Inventory)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_film_id_fkey");
        }
    }
}

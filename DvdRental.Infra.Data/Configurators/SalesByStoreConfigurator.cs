using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class SalesByStoreConfigurator : IEntityTypeConfiguration<SalesByStore>
    {
        public void Configure(EntityTypeBuilder<SalesByStore> entity)
        {
            entity.HasNoKey();

            entity.ToTable("sales_by_store");

            entity.Property(e => e.Manager).HasColumnName("manager");

            entity.Property(e => e.Store).HasColumnName("store");

            entity.Property(e => e.TotalSales)
                .HasColumnName("total_sales")
                .HasColumnType("numeric");
        }
    }
}

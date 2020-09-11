using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class SalesByFilmCategoryConfigurator : IEntityTypeConfiguration<SalesByFilmCategory>
    {
        public void Configure(EntityTypeBuilder<SalesByFilmCategory> entity)
        {
            entity.HasNoKey();

            entity.ToTable("sales_by_film_category");

            entity.Property(e => e.Category)
                .HasColumnName("category")
                .HasMaxLength(25);

            entity.Property(e => e.TotalSales)
                .HasColumnName("total_sales")
                .HasColumnType("numeric");
        }
    }
}

using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class CategoryConfigurator : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(25);
        }
    }
}

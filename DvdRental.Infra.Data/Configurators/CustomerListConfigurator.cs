using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class CustomerListConfigurator : IEntityTypeConfiguration<CustomerList>
    {
        public void Configure(EntityTypeBuilder<CustomerList> entity)
        {
            entity.HasNoKey();

            entity.ToTable("customer_list");

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

            entity.Property(e => e.Notes).HasColumnName("notes");

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

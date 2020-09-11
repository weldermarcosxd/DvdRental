using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class LanguageConfigurator : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.ToTable("language");

            entity.Property(e => e.LanguageId).HasColumnName("language_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(20)
                .IsFixedLength();
        }
    }
}

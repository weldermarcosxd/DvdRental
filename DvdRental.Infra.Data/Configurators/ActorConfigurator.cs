using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class ActorConfigurator : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> entity)
        {
            entity.ToTable("actor");

            entity.HasIndex(e => e.LastName)
                .HasName("idx_actor_last_name");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");

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
        }
    }
}

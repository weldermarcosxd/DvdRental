using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class ActorInfoConfigurator : IEntityTypeConfiguration<ActorInfo>
    {
        public void Configure(EntityTypeBuilder<ActorInfo> entity)
        {
            entity.HasNoKey();

            entity.ToTable("actor_info");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");

            entity.Property(e => e.FilmInfo).HasColumnName("film_info");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(45);

            entity.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(45);
        }
    }
}

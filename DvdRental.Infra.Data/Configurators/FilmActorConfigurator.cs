using DvdRentalDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DvdRental.Infra.Data.Configurators
{
    public class FilmActorConfigurator : IEntityTypeConfiguration<FilmActor>
    {
        public void Configure(EntityTypeBuilder<FilmActor> entity)
        {
            entity.HasKey(e => new { e.ActorId, e.FilmId })
                    .HasName("film_actor_pkey");

            entity.ToTable("film_actor");

            entity.HasIndex(e => e.FilmId)
                .HasName("idx_fk_film_id");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");

            entity.Property(e => e.FilmId).HasColumnName("film_id");

            entity.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasDefaultValueSql("now()");

            entity.HasOne(d => d.Actor)
                .WithMany(p => p.FilmActor)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("film_actor_actor_id_fkey");

            entity.HasOne(d => d.Film)
                .WithMany(p => p.FilmActor)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("film_actor_film_id_fkey");
        }
    }
}

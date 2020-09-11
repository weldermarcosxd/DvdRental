using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DvdRentalDomain.Entities
{
    public partial class DvdRentalContext : DbContext
    {
        public DvdRentalContext()
        {
        }

        public DvdRentalContext(DbContextOptions<DvdRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<ActorInfo> ActorInfo { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerList> CustomerList { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmActor> FilmActor { get; set; }
        public virtual DbSet<FilmCategory> FilmCategory { get; set; }
        public virtual DbSet<FilmList> FilmList { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<NicerButSlowerFilmList> NicerButSlowerFilmList { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<SalesByFilmCategory> SalesByFilmCategory { get; set; }
        public virtual DbSet<SalesByStore> SalesByStore { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffList> StaffList { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "mpaa_rating", new[] { "G", "PG", "PG-13", "R", "NC-17" });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.HasSequence("actor_actor_id_seq");

            modelBuilder.HasSequence("address_address_id_seq");

            modelBuilder.HasSequence("category_category_id_seq");

            modelBuilder.HasSequence("city_city_id_seq");

            modelBuilder.HasSequence("country_country_id_seq");

            modelBuilder.HasSequence("customer_customer_id_seq");

            modelBuilder.HasSequence("film_film_id_seq");

            modelBuilder.HasSequence("inventory_inventory_id_seq");

            modelBuilder.HasSequence("language_language_id_seq");

            modelBuilder.HasSequence("payment_payment_id_seq");

            modelBuilder.HasSequence("rental_rental_id_seq");

            modelBuilder.HasSequence("staff_staff_id_seq");

            modelBuilder.HasSequence("store_store_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

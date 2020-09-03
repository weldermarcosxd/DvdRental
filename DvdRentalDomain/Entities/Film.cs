using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace DvdRentalDomain.Entities
{
    public partial class Film
    {
        public Film()
        {
            FilmActor = new HashSet<FilmActor>();
            FilmCategory = new HashSet<FilmCategory>();
            Inventory = new HashSet<Inventory>();
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public short RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public DateTime LastUpdate { get; set; }
        public string[] SpecialFeatures { get; set; }
        public NpgsqlTsVector Fulltext { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<FilmActor> FilmActor { get; set; }
        public virtual ICollection<FilmCategory> FilmCategory { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}

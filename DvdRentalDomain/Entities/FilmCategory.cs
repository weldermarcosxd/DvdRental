using System;

namespace DvdRentalDomain.Entities
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}

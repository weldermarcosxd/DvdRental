using System;
using System.Collections.Generic;

namespace DvdRentalDomain.Entities
{
    public partial class Language
    {
        public Language()
        {
            Film = new HashSet<Film>();
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DvdRentalDomain.Entities
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public int CityId { get; set; }
        public string City1 { get; set; }
        public int CountryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}

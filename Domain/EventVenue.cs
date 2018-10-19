using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventVenue
    {
        [Key]
        public int VenueID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}

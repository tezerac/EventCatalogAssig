using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventOrganizer
    {
       [Key]

        public int OrganizerID { get; set; }
        public string OrganizerName { get; set; }
        public string Description { get; set; }
        public string OrganizerUrl { get; set; }
    }
}

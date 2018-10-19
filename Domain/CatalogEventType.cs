using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEventType//event Topic
    {
        [Key]
        public int EventTypeID { get; set; }
        public string EventTypeName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEventTopic
    {
        [Key]
        public int EventTopicID { get; set; }
        public string EventTopicName { get; set; }
        public string LocalizedName { get; set; }
        public string ShortName { get; set; }
    }
}

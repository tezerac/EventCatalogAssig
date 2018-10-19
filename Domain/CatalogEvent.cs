using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEvent
    {   
        [Key]
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string EventStartDate { get; set; }//should be datetime
        public string EventEndDate { get; set; }//should be datetime
        public string EventStartTime { get; set; }//should be datetime
        public string EventEndTime  { get; set; }//should be datetime
        public string CurrentStatus { get; set; }
        public string EventImageUrl { get; set; }//logo
        public string EventAddress { get; set; }
        public string EventUrl { get; set; }

        public int EventTopicID { get; set; }//fk
        public int EventTypeID { get; set; }//fk
        public int EventVenueID { get; set; }//fk
        public int EventOrganizerID { get; set; }//fk

        public virtual CatalogEventTopic EventTopic { get; set; }
        public virtual CatalogEventType EventType { get; set; }
        public virtual EventVenue EventVenue { get; set; }
        public virtual EventOrganizer EventOrganizer { get; set; }
    }
}




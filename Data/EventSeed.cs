using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventSeed
    {

        public static async Task SeedAsync(EventContext context)
        {
            //uding lounch setting we can populate the database
            //lounch setting for windows iis and for linux comcast
            //instead of performing migration manually using consol manager 
            //we can use the seedAsync method and we can write inside the code
            //as context.database.migrate() method
            //this is the way to fill the created tables with the data
            //and should be created in the data folder
            //seedasync catalogcontext
            //seed async=feel my table
            //first migrate to the database
            //once it migrate to the databse then it will see the change and update the change only.
            //then we only wont to keep a dumy row in the database if it has no any rows
            context.Database.Migrate();

            if (!context.EventTopics.Any())
            {
                context.EventTopics.AddRange
                    (GetPreconfiguredEventCatagories());
                 context.SaveChanges();
            }

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange
                    (GetPreconfiguredEventTypes());
                 context.SaveChanges();
            }
            if (!context.EventVenues.Any())
            {
                context.EventVenues.AddRange
                    (GetPreconfiguredEventVenues());
                 context.SaveChanges();
            }
            if (!context.Organizers.Any())
            {
                context.Organizers.AddRange
                    (GetPreconfiguredEventOrganizers());
                context.SaveChanges();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange
                    (GetPreconfiguredEvents());
              await  context.SaveChangesAsync();
            }

        }

        private static IEnumerable<CatalogEventTopic> GetPreconfiguredEventCatagories()
        {
            return new List<CatalogEventTopic>()
            {
                new CatalogEventTopic{EventTopicName="Business and Professionals", LocalizedName="", ShortName="Bus&Pro"},
                 new CatalogEventTopic{EventTopicName="Food and Drink", LocalizedName="", ShortName="Food"},
                  new CatalogEventTopic{EventTopicName="School and Activities", LocalizedName="", ShortName="Schools"},

            };
        }
        private static IEnumerable<CatalogEventType> GetPreconfiguredEventTypes()
        {
            return new List<CatalogEventType>()
            {
                new CatalogEventType{EventTypeName="WorkShop"},
                new CatalogEventType{EventTypeName="Expo"},
                new CatalogEventType{EventTypeName="Training"},
                new CatalogEventType{EventTypeName="Get together Party"},
                new CatalogEventType{EventTypeName="Trade show"},
                new CatalogEventType{EventTypeName="Consumer Show"},
                new CatalogEventType{EventTypeName="Dinner"},
                new CatalogEventType{EventTypeName="Party"},
                new CatalogEventType{EventTypeName="Tournament"},
                new CatalogEventType{EventTypeName="Tour"},
                new CatalogEventType{EventTypeName="Weeding"}
            };
        }

        private static IEnumerable<EventVenue> GetPreconfiguredEventVenues()
        {
            return new List<EventVenue>()
            {
                new EventVenue{Name="BELMONT",Address="518 E. Pike Street Seattle, WA, 98122",longitude="47° 36' 28.8468'' N",latitude="122° 20' 6.6012'' W"},
                new EventVenue{Name="The Conference Center",Address="Sea-Tac Airport ",longitude="47° 36' 28.8468'' N",latitude="122° 20' 6.6012'' W"},
                new EventVenue{Name="Georgetown Ballroom",Address="5623 Airport Way South Seattle WA 98108",longitude="47° 36' 28.8468'' N",latitude="122° 20' 6.6012'' W"},
                new EventVenue{Name="Canvas Space",Address="3412 4th Ave S 3412 4th Ave S, Seattle, WA 98134",longitude="47° 36' 28.8468'' N",latitude="122° 20' 6.6012'' W"}
            };
        }
        private static IEnumerable<EventOrganizer> GetPreconfiguredEventOrganizers()
        {
            return new List<EventOrganizer>()
            {
                new EventOrganizer{OrganizerName="PBIVEBARS",Description="With over fifteen years experience",OrganizerUrl="https://www.prive-events.com/"},
                new EventOrganizer{OrganizerName="A Kurant Event",Description="Seattle Wedding & Event Planner",OrganizerUrl="http://www.akurantevent.com/"},
                new EventOrganizer{OrganizerName="The Ginger Bee",Description="Wedding and Event Planner Based in Seattle, WA",OrganizerUrl="http://www.gingerbeeevents.com/"},
                new EventOrganizer{OrganizerName="Well Done Events, LLC",Description="We are event management experts.",OrganizerUrl="http://www.welldonevents.com/"}
            };

        }
        private static IEnumerable<CatalogEvent> GetPreconfiguredEvents()
        {
            return new List<CatalogEvent>()
            {
                new CatalogEvent() { EventTopicID=1,EventTypeID=1,EventOrganizerID=1,EventVenueID=3, EventName="Business and Expo", Description ="Show your support and have a voice that helps influence our industry's community in the Pacific Northwest! Become a Patron of IIDA's Northern Pacific Chapter at any of the 5 levels of sponsorship opportunities offered.",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2018",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="Url: https://www.eventbrite.com/e/iida-npc-2019-patron-drive-tickets-50628226388?aff=ebdssbdestsearch",EventAddress="PO Box 12826 Seattle, WA 98111 ",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/1" },
                new CatalogEvent() { EventTopicID=1,EventTypeID=2,EventOrganizerID=2,EventVenueID=2, EventName="Business and Expo", Description ="Lunch will be served at the Summit, and cocktail reception will immediately follow the end of the program from 4:30 - 6:00 PM.",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2018",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="https://www.eventbrite.com/e/4th-annual-family-and-closely-held-business-summit-tickets-48250636954?aff=ebdssbdestsearch",EventAddress="Bell Harbor International Conference Center 2211 Alaskan Way Seattle, WA 98121",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/2" },
                new CatalogEvent() { EventTopicID=1,EventTypeID=5,EventOrganizerID=3,EventVenueID=1, EventName="Business and Expo", Description ="We have invited some of our most popular winemakers back to host one course each. ",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2018",EventStartTime ="7am" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="https://www.eventbrite.com/e/winemaker-dinner-best-of-2018-tickets-51345994251?aff=ebdssbdestsearch",EventAddress="Revolve True Food & Wine Bar 10024 Main Street Bothell, WA 98011",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/7" },
                new CatalogEvent() { EventTopicID=1,EventTypeID=6,EventOrganizerID=4,EventVenueID=4, EventName="Food and drink", Description ="This is the only way we will be able to send you the access link you need to join in.",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2018",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="https://www.eventbrite.com/e/6-non-pushy-ways-to-follow-up-that-will-win-you-new-and-repeat-business-over-and-over-again-free-tickets-51321706606?aff=ebdssbdestsearch",EventAddress="Seattle, Washington",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/6" },
                new CatalogEvent() { EventTopicID=2,EventTypeID=4, EventOrganizerID=1,EventVenueID=3,EventName="Business and Expo", Description ="If you attend the first meeting and you don't love it, you'll get 90% of your money back. And, since this is a small group, if you sign up and don't show, your ticket is non-refundable.",EventStartDate ="01/03/2019" ,EventEndDate ="01/01/2018",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="https://www.eventbrite.com/e/-sold-out-starting-toward-extraordinary-6-week-business-building-group-tickets-38826320570?aff=ebdssbdestsearch",EventAddress="Seattle - SODO Area ",EventImageUrl="http://evnetPicturetobereplaced/api/EventPics/5" },
                new CatalogEvent() { EventTopicID=2,EventTypeID=7,EventOrganizerID=2,EventVenueID=2, EventName="Sport Event", Description ="The Meridian School Parent Association invites you to join us for an all-out afternoon celebration in the midsts of our beautiful ",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2018",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="https://www.eventbrite.com/e/the-meridian-school-fall-festival-2018-tickets-50939182466?aff=ebdssbdestsearch",EventAddress="The Meridian School 4649 Sunnyside Avenue North Seattle, WA 98103",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/3" },
                new CatalogEvent() { EventTopicID=2,EventTypeID=11, EventOrganizerID=3,EventVenueID=1,EventName="Business and Expo", Description ="Come meet other students passionate about health equity issues!",EventStartDate ="01/05/2018" ,EventEndDate ="01/01/2017",EventStartTime ="11am" ,EventEndTime ="3am",CurrentStatus="Expired",EventUrl="https://www.eventbrite.com/e/health-equity-circles-2018-general-assembly-tickets-50938210559?aff=ebdssbdestsearch",EventAddress="University of Washington Vista Cafe, Foege Hall",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/10" },
                new CatalogEvent() { EventTopicID=3,EventTypeID=8,EventOrganizerID=4,EventVenueID=4, EventName="School Event", Description ="October can be a dark and stormy month in SEA — sooo, one dreamy morning: coming right up..Now or Never",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2018",EventStartTime ="10am" ,EventEndTime ="3pm",CurrentStatus="Postponed",EventUrl=" https://www.eventbrite.com/e/daybreaker-sea-never-never-land-tickets-50566439582?aff=ebdssbcitybrowse",EventAddress="1021 E Pine St, Seattle, WA 98122",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/11" },
                new CatalogEvent() { EventTopicID=3,EventTypeID=9, EventOrganizerID=1,EventVenueID=3,EventName="Business and Expo", Description ="Psychic school is back by popular demand! Whether you experienced one of our first psychic school workshops and want to dive deeper",EventStartDate ="01/01/2018" ,EventEndDate ="04/01/2018",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Active",EventUrl="https://www.eventbrite.com/e/psychic-school-2-tickets-50229487750?aff=ebdssbdestsearch",EventAddress="Eka Yoga 621 5th Avenue North Suite B Seattle, WA 98109",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/8" },
                new CatalogEvent() { EventTopicID=3,EventTypeID=10,EventOrganizerID=2,EventVenueID=2, EventName="Business and Expo", Description ="The Dinner Detective: An Interactive Murdery Mystery Dinner Show",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2017",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Closed",EventUrl="https://www.goldstar.com/get-started/eventbrite/160742?aff_sub=160742&test_signup&transaction_id=102fba858cbadc85d70849dc28681a&purchase_goal=0&amount=our_price_and_service_fees&utm_source=has_offers&utm_medium=affiliates&utm_content=4869&utm_campaign=affiliate_program",EventAddress="Crowne Plaza Seattle Downtown - Seattle",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/4" },
                new CatalogEvent() { EventTopicID=3,EventTypeID=3,EventOrganizerID=3,EventVenueID=1, EventName="Business and Expo", Description ="As a Research 1 institution, we are consistently on the forefront of groundbreaking reserach that involves some of the best faculty",EventStartDate ="01/01/2018" ,EventEndDate ="01/01/2017",EventStartTime ="2pm" ,EventEndTime ="3pm",CurrentStatus="Closed",EventUrl="https://www.eventbrite.com/e/mpfs-undergraduate-research-program-workshop-tickets-51307409844?aff=ebdssbdestsearch",EventAddress="Alder Hall - Room 105 1315 Northeast Campus Parkway Seattle, WA 98105",EventImageUrl="http://externalcatalogbaseurltobereplaced/api/EventPics/9" }
            };
        }
    }
}
            
      
    
                 
                
    


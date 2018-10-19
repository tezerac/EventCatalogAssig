using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<CatalogEventTopic> EventTopics { get; set; }
        public DbSet<CatalogEventType> EventTypes { get; set; }
        public DbSet<CatalogEvent> Events { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
        public DbSet<EventOrganizer> Organizers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogEventTopic>(ConfigureCatalogEventTopic);
            modelBuilder.Entity<CatalogEventType>(ConfigureCatalogEventType);
            modelBuilder.Entity<CatalogEvent>(ConfigureCatalogEvent);
            modelBuilder.Entity<EventVenue>(ConfigureEventVenue);
            modelBuilder.Entity<EventOrganizer>(ConfigureEventOrganizer);
        }


        private void ConfigureCatalogEventTopic
            (EntityTypeBuilder<CatalogEventTopic> builder)
        {
            builder.ToTable("CatalogEventTopic");
            builder.Property(x => x.EventTopicID)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("Catalog_EventTopic_Hilo");

            builder.Property(x => x.EventTopicName)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(x => x.LocalizedName)
              .IsRequired(false)
              .HasMaxLength(100);

            builder.Property(x => x.ShortName)
             .IsRequired(false)
             .HasMaxLength(100);
        }
        private void ConfigureCatalogEventType
            (EntityTypeBuilder<CatalogEventType> builder)
        {
            builder.ToTable("CatalogEventType");
            builder.Property(x => x.EventTypeID)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("Catalog_EventType_Hilo");

            builder.Property(x => x.EventTypeName)
                  .IsRequired()
                  .HasMaxLength(100);
        }

        private void ConfigureEventVenue
            (EntityTypeBuilder<EventVenue> builder)
        {
            builder.ToTable("EventVenue");
            builder.Property(x => x.VenueID)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("Catalog_EventVenue_Hilo");

            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(x => x.Address)
              .IsRequired(false)
              .HasMaxLength(400);

            builder.Property(x =>x.longitude)
             .IsRequired(false)
             .HasMaxLength(100);

            builder.Property(x => x.latitude)
            .IsRequired(false)
            .HasMaxLength(100);
        }

        private void ConfigureEventOrganizer
           (EntityTypeBuilder<EventOrganizer> builder)
        {
            builder.ToTable("EventOrganizer");
            builder.Property(x => x.OrganizerID)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("Catalog_Organizer_Hilo");

            builder.Property(x => x.OrganizerName)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(x => x.Description)
              .IsRequired(false)
              .HasMaxLength(400);

            builder.Property(x => x.OrganizerUrl)
             .IsRequired(false)
             .HasMaxLength(400);
        }

        
        private void ConfigureCatalogEvent
            (EntityTypeBuilder<CatalogEvent> builder)
        {
            builder.ToTable("CatalogEvent");
            builder.Property(x => x.EventID)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("Catalog_CatalogEvent_Hilo");

            builder.Property(x => x.EventName)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(x => x.Description)
              .IsRequired()
              .HasMaxLength(2000);

            builder.Property(x => x.EventStartDate)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(x => x.EventEndDate)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(x => x.EventStartTime)
             .IsRequired(false)
             .HasMaxLength(100);

            builder.Property(x => x.EventEndTime)
                 .IsRequired(false)
                 .HasMaxLength(100);

            builder.Property(x => x.CurrentStatus)
              .IsRequired(false)
              .HasMaxLength(100);

            builder.Property(x => x.EventImageUrl)
              .IsRequired()
              .HasMaxLength(100);

            builder.Property(x => x.EventAddress)
                  .IsRequired(false)
                  .HasMaxLength(400);

            builder.Property(x => x.EventUrl)
             .IsRequired(false)
             .HasMaxLength(400);

           builder.HasOne(x => x.EventType)
                .WithMany()
                .HasForeignKey(x => x.EventTypeID);

            builder.HasOne(x => x.EventTopic)
                .WithMany()
                .HasForeignKey(x => x.EventTopicID);

            builder.HasOne(x => x.EventVenue)
                .WithMany()
                .HasForeignKey(x => x.EventVenueID);

            builder.HasOne(x => x.EventOrganizer)
                .WithMany()
                .HasForeignKey(x => x.EventOrganizerID);


        }
    }
}

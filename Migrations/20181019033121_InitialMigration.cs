using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Catalog_CatalogEvent_Hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Catalog_EventTopic_Hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Catalog_EventType_Hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Catalog_EventVenue_Hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Catalog_Organizer_Hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogEventTopic",
                columns: table => new
                {
                    EventTopicID = table.Column<int>(nullable: false),
                    EventTopicName = table.Column<string>(maxLength: 100, nullable: false),
                    LocalizedName = table.Column<string>(maxLength: 100, nullable: true),
                    ShortName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventTopic", x => x.EventTopicID);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventType",
                columns: table => new
                {
                    EventTypeID = table.Column<int>(nullable: false),
                    EventTypeName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventType", x => x.EventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganizer",
                columns: table => new
                {
                    OrganizerID = table.Column<int>(nullable: false),
                    OrganizerName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    OrganizerUrl = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizer", x => x.OrganizerID);
                });

            migrationBuilder.CreateTable(
                name: "EventVenue",
                columns: table => new
                {
                    VenueID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 400, nullable: true),
                    longitude = table.Column<string>(maxLength: 100, nullable: true),
                    latitude = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVenue", x => x.VenueID);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEvent",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    EventStartDate = table.Column<string>(maxLength: 100, nullable: false),
                    EventEndDate = table.Column<string>(maxLength: 100, nullable: false),
                    EventStartTime = table.Column<string>(maxLength: 100, nullable: true),
                    EventEndTime = table.Column<string>(maxLength: 100, nullable: true),
                    CurrentStatus = table.Column<string>(maxLength: 100, nullable: true),
                    EventImageUrl = table.Column<string>(maxLength: 100, nullable: false),
                    EventAddress = table.Column<string>(maxLength: 400, nullable: true),
                    EventUrl = table.Column<string>(maxLength: 400, nullable: true),
                    EventTopicID = table.Column<int>(nullable: false),
                    EventTypeID = table.Column<int>(nullable: false),
                    EventVenueID = table.Column<int>(nullable: false),
                    EventOrganizerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEvent", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_CatalogEvent_EventOrganizer_EventOrganizerID",
                        column: x => x.EventOrganizerID,
                        principalTable: "EventOrganizer",
                        principalColumn: "OrganizerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEvent_CatalogEventTopic_EventTopicID",
                        column: x => x.EventTopicID,
                        principalTable: "CatalogEventTopic",
                        principalColumn: "EventTopicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEvent_CatalogEventType_EventTypeID",
                        column: x => x.EventTypeID,
                        principalTable: "CatalogEventType",
                        principalColumn: "EventTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEvent_EventVenue_EventVenueID",
                        column: x => x.EventVenueID,
                        principalTable: "EventVenue",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvent_EventOrganizerID",
                table: "CatalogEvent",
                column: "EventOrganizerID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvent_EventTopicID",
                table: "CatalogEvent",
                column: "EventTopicID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvent_EventTypeID",
                table: "CatalogEvent",
                column: "EventTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvent_EventVenueID",
                table: "CatalogEvent",
                column: "EventVenueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogEvent");

            migrationBuilder.DropTable(
                name: "EventOrganizer");

            migrationBuilder.DropTable(
                name: "CatalogEventTopic");

            migrationBuilder.DropTable(
                name: "CatalogEventType");

            migrationBuilder.DropTable(
                name: "EventVenue");

            migrationBuilder.DropSequence(
                name: "Catalog_CatalogEvent_Hilo");

            migrationBuilder.DropSequence(
                name: "Catalog_EventTopic_Hilo");

            migrationBuilder.DropSequence(
                name: "Catalog_EventType_Hilo");

            migrationBuilder.DropSequence(
                name: "Catalog_EventVenue_Hilo");

            migrationBuilder.DropSequence(
                name: "Catalog_Organizer_Hilo");
        }
    }
}

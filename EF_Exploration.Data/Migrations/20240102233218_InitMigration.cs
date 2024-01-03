using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Exploration.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    HomeRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentWins = table.Column<double>(type: "float", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssistantCoaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistantCoaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistantCoaches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeadCoaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadCoaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadCoaches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "American Football Conference" },
                    { 2, "National Football Conference" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "ConferenceId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "AFC EAST" },
                    { 2, 1, "AFC North" },
                    { 3, 1, "AFC SOUTH" },
                    { 4, 1, "AFC WEST" },
                    { 5, 2, "NFC EAST" },
                    { 6, 2, "NFC NORTH" },
                    { 7, 2, "NFC SOUTH" },
                    { 8, 2, "NFC WEST" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "DivisionId", "HomeRecord", "Losses", "Name", "PercentWins", "RoadRecord", "Ties", "Wins" },
                values: new object[,]
                {
                    { 1, 1, "7-1-0", 5, "Miami Dolphins", 0.0, "4-4-0", 0, 11 },
                    { 2, 1, "7-2-0", 6, "Buffalo Bills", 0.0, "3-4-0", 0, 10 },
                    { 3, 1, "4-5-0", 10, "New York Jets", 0.0, "2-5-0", 0, 6 },
                    { 4, 1, "1-7-0", 12, "New England Patriots", 0.0, "3-5-0", 0, 4 },
                    { 5, 2, "6-2-0", 3, "Baltimore Ravens", 0.0, "7-1-0", 0, 13 },
                    { 6, 2, "8-1-0", 5, "Cleveland Browns", 0.0, "3-4-0", 0, 11 },
                    { 7, 2, "5-4-0", 7, "Pittsburgh Steelers", 0.0, "4-3-0", 0, 9 },
                    { 8, 2, "5-3-0", 8, "Cincinnati Bengals", 0.0, "3-5-0", 0, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistantCoaches_TeamId",
                table: "AssistantCoaches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ConferenceId",
                table: "Divisions",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCoaches_TeamId",
                table: "HeadCoaches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DivisionId",
                table: "Teams",
                column: "DivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistantCoaches");

            migrationBuilder.DropTable(
                name: "HeadCoaches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}

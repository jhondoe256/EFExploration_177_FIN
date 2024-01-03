using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Exploration.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeadCoachFK_FOR_ONE_TO_ONE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeadCoaches_TeamId",
                table: "HeadCoaches");

            migrationBuilder.AddColumn<int>(
                name: "HeadCoachId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8,
                column: "HeadCoachId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HeadCoaches_TeamId",
                table: "HeadCoaches",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeadCoaches_TeamId",
                table: "HeadCoaches");

            migrationBuilder.DropColumn(
                name: "HeadCoachId",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCoaches_TeamId",
                table: "HeadCoaches",
                column: "TeamId");
        }
    }
}

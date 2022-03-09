using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class ChangedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "canoe",
                column: "Name",
                value: "Canoe Sprint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "canoe",
                column: "Name",
                value: "Canoe Spring");
        }
    }
}

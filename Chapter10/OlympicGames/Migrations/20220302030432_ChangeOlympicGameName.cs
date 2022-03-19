using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class ChangeOlympicGameName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OlympicGameName",
                table: "Games",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "canoe",
                column: "Indoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "cycle",
                column: "Indoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "skate",
                column: "Indoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "sled",
                column: "Indoor",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Games",
                newName: "OlympicGameName");

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "canoe",
                column: "Indoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "cycle",
                column: "Indoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "skate",
                column: "Indoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportID",
                keyValue: "sled",
                column: "Indoor",
                value: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class Intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    OlympicGameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OlympicGameName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.OlympicGameID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indoor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OlympicGameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Games_OlympicGameID",
                        column: x => x.OlympicGameID,
                        principalTable: "Games",
                        principalColumn: "OlympicGameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[,]
                {
                    { "ca", "Canada" },
                    { "pt", "Portugal" },
                    { "sk", "Slovakia" },
                    { "fi", "Finland" },
                    { "ru", "Russia" },
                    { "cy", "Cyprus" },
                    { "fr", "France" },
                    { "pk", "Pakistan" },
                    { "at", "Austria" },
                    { "ua", "Ukraine" },
                    { "uy", "Uruguay" },
                    { "th", "Thailand" },
                    { "zw", "Zimbabwe" },
                    { "nl", "Netherlands" },
                    { "br", "Brazil" },
                    { "mx", "Mexico" },
                    { "cn", "China" },
                    { "de", "Germany" },
                    { "jp", "Japan" },
                    { "it", "Italy" },
                    { "jm", "Jamaica" },
                    { "gb", "Great Britain" },
                    { "se", "Sweden" },
                    { "us", "USA" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "OlympicGameID", "OlympicGameName" },
                values: new object[,]
                {
                    { "youth", "Youth Olympics" },
                    { "para", "Paralympics" },
                    { "winter", "Winter Olympics" },
                    { "summer", "Summer Olympics" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportID", "Indoor", "Name" },
                values: new object[,]
                {
                    { "dance", true, "Breakdancing" },
                    { "curl", true, "Curling" },
                    { "sled", true, "Bobsleigh" },
                    { "dive", true, "Diving" },
                    { "cycle", true, "Road Cycling" },
                    { "arch", true, "Archery" },
                    { "canoe", true, "Canoe Spring" },
                    { "skate", true, "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "CountryID", "OlympicGameID", "SportID" },
                values: new object[,]
                {
                    { 1, "ca", "winter", "curl" },
                    { 22, "fi", "youth", "skate" },
                    { 21, "ru", "youth", "dance" },
                    { 20, "cy", "youth", "dance" },
                    { 19, "fr", "youth", "dance" },
                    { 18, "zw", "para", "canoe" },
                    { 17, "pk", "para", "canoe" },
                    { 16, "at", "para", "canoe" },
                    { 15, "ua", "para", "arch" },
                    { 14, "uy", "para", "arch" },
                    { 13, "th", "para", "arch" },
                    { 12, "us", "summer", "cycle" },
                    { 11, "nl", "summer", "cycle" },
                    { 10, "br", "summer", "cycle" },
                    { 9, "mx", "summer", "dive" },
                    { 8, "cn", "summer", "dive" },
                    { 7, "de", "summer", "dive" },
                    { 6, "jp", "winter", "sled" },
                    { 5, "it", "winter", "sled" },
                    { 4, "jm", "winter", "sled" },
                    { 3, "gb", "winter", "curl" },
                    { 2, "se", "winter", "curl" },
                    { 23, "sk", "youth", "skate" },
                    { 24, "pt", "youth", "skate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryID",
                table: "Teams",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OlympicGameID",
                table: "Teams",
                column: "OlympicGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportID",
                table: "Teams",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}

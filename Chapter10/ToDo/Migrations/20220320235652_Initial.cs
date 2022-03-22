using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    SprintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.SprintId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    SprintId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sprints",
                columns: new[] { "SprintId", "DueDate", "Name" },
                values: new object[,]
                {
                    { -1, null, "No Sprint" },
                    { 1, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 1" },
                    { 2, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 2" },
                    { 3, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 3" },
                    { 4, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 4" },
                    { 5, new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 5" },
                    { 6, new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 6" },
                    { 7, new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 7" },
                    { 8, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 8" },
                    { 9, new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 9" },
                    { 10, new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 10" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "todo", "To Do" },
                    { "inprog", "In Progress" },
                    { "qa", "Quality Assurance" },
                    { "done", "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SprintId",
                table: "Tickets",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}

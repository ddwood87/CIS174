using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations
{
    public partial class AddedTicketSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Name", "Points", "SprintId", "StatusId" },
                values: new object[,]
                {
                    { 1, "Job Number 1", "Ticket 1", 1, 1, "todo" },
                    { 2, "Job Number 2", "Ticket 2", 3, 1, "inprog" },
                    { 3, "Job Number 3", "Ticket 3", 1, 2, "todo" },
                    { 4, "Job Number 4", "Ticket 4", 1, 2, "inprog" },
                    { 5, "Job Number 5", "Ticket 5", 4, 3, "todo" },
                    { 6, "Job Number 6", "Ticket 6", 6, 3, "inprog" },
                    { 7, "Job Number 7", "Ticket 7", 7, 4, "todo" },
                    { 8, "Job Number 8", "Ticket 8", 6, 4, "inprog" },
                    { 9, "Job Number 9", "Ticket 9", 5, 5, "todo" },
                    { 10, "Job Number 10", "Ticket 10", 6, 5, "inprog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations
{
    public partial class ChangedSprintDueDateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 6,
                column: "DueDate",
                value: new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 7,
                column: "DueDate",
                value: new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 8,
                column: "DueDate",
                value: new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 9,
                column: "DueDate",
                value: new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 6,
                column: "DueDate",
                value: new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 7,
                column: "DueDate",
                value: new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 8,
                column: "DueDate",
                value: new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 9,
                column: "DueDate",
                value: new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sprints",
                keyColumn: "SprintId",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

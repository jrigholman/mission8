using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mission8.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 1, 1, false, new DateTime(2025, 3, 1, 17, 30, 8, 265, DateTimeKind.Local).AddTicks(9522), 2, "Buy groceries" });
        }
    }
}

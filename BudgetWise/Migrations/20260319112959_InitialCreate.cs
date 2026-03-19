using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetWise.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Category", "Date", "Description", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 5000m, "Salary", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly salary", 1, "demo" },
                    { 2, 120m, "Food", new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Groceries", 2, "demo" },
                    { 3, 60m, "Transport", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gas", 2, "demo" },
                    { 4, 800m, "Housing", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rent", 2, "demo" },
                    { 5, 500m, "Freelance", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design project", 1, "demo" },
                    { 6, 45m, "Entertainment", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Movie tickets", 2, "demo" },
                    { 7, 200m, "Shopping", new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clothes", 2, "demo" },
                    { 8, 90m, "Health", new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pharmacy", 2, "demo" },
                    { 9, 150m, "Education", new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Online course", 2, "demo" },
                    { 10, 35m, "Food", new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restaurant", 2, "demo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

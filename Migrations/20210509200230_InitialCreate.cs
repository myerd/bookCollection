using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookCollection.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Name" },
                values: new object[] { new Guid("bbca9711-b2e9-4c00-a209-9e3c4c6d7f1b"), "J.K. Rowling", "Story of wizard", "Harry Potter 1" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Name" },
                values: new object[] { new Guid("f71ac3a3-2dc6-4692-80e8-4c05b498ac5c"), "J.R.R Tolkien", "Tale of the ring", "Lord of the Rings" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Name" },
                values: new object[] { new Guid("0a1d19a4-3fc1-4e6f-aa78-81f0488ba9a3"), "Various", "The book of cooking", "Supreme Cooking book" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Name" },
                values: new object[] { new Guid("7c805f3a-763a-4315-9be1-c5b02482d357"), "Book author", "Just filling database", "Random Generator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "466e7c96-8b84-40d5-a795-4ccc9c13de51", "15db544a-0d43-4205-be77-e396c08cba61", "Admin", "ADMIN" },
                    { "6cd692d1-0d06-44a0-b700-73463ea92616", "19576de0-2011-47b9-b1b3-c86cba586076", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "466e7c96-8b84-40d5-a795-4ccc9c13de51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd692d1-0d06-44a0-b700-73463ea92616");
        }
    }
}

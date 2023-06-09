using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Orders");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Orders",
                type: "date",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cfc849e-5e6f-4b4f-b6d2-0aae0468d738", "AQAAAAIAAYagAAAAELdI3cC6dgG0vwsbogts7sW8bv4NoDRsktGTQSvRtqH4Gzn/66SlAlsDDkTYo73J+A==", "d12196cb-8b40-4b11-908a-2f0074977bce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1652b48e-bb0f-4499-8343-aba520d0b1bb", "AQAAAAIAAYagAAAAEKmYGbexa/SMHzoAS/q2udnDihWnXZ+l8YhubiQJOODz+UQX5Ema7pqmQlDALjXfkg==", "81257f36-7dce-48db-8dc2-94709513b487" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToDeviceDataPiece : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "DeviceDataPieces",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c1e8671-977c-45c3-bd5c-684264cd841d", "AQAAAAIAAYagAAAAENmGVn0JclM5Q8mDqtZbMTTC0zKlRWERUnCNExF+/Nf5fripG8CyL4ZIbAhzOvdU1g==", "469733e4-ad3b-4a86-9252-188b06dbf567" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "DeviceDataPieces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cfc849e-5e6f-4b4f-b6d2-0aae0468d738", "AQAAAAIAAYagAAAAELdI3cC6dgG0vwsbogts7sW8bv4NoDRsktGTQSvRtqH4Gzn/66SlAlsDDkTYo73J+A==", "d12196cb-8b40-4b11-908a-2f0074977bce" });
        }
    }
}

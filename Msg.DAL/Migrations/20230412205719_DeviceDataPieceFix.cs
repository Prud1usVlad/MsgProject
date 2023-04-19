using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeviceDataPieceFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "DeviceDataPieces",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f560414-8fcb-421e-af6a-375557f5f747", "AQAAAAIAAYagAAAAED/+4orKoIwyB/BcwNsFmnA1TWN3J+cpRFO0wqQYzChTYqKAJ/qXGK3PyLClsDQfDA==", "5cd6bac1-5aac-442c-a065-f45e09f59620" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeviceDataPieces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c1e8671-977c-45c3-bd5c-684264cd841d", "AQAAAAIAAYagAAAAENmGVn0JclM5Q8mDqtZbMTTC0zKlRWERUnCNExF+/Nf5fripG8CyL4ZIbAhzOvdU1g==", "469733e4-ad3b-4a86-9252-188b06dbf567" });
        }
    }
}

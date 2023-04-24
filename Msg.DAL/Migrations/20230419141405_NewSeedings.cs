using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DevicesInPacks",
                table: "DevicesInPacks");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "DevicesInPacks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevicesInPacks",
                table: "DevicesInPacks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df20681b-e31d-4d57-bbdb-43a522d7695c", "AQAAAAIAAYagAAAAED8whPEqNxi6a6eK36eaLSXIJCzp6kcPzXZwQEZGbWkxM/4Q7vRZcjnqwXnp4l+P7A==", "d432d47d-18fa-4f7a-9a28-f20cb9a390be" });

            migrationBuilder.CreateIndex(
                name: "IX_DevicesInPacks_PackTypeId",
                table: "DevicesInPacks",
                column: "PackTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DevicesInPacks",
                table: "DevicesInPacks");

            migrationBuilder.DropIndex(
                name: "IX_DevicesInPacks_PackTypeId",
                table: "DevicesInPacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DevicesInPacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevicesInPacks",
                table: "DevicesInPacks",
                columns: new[] { "PackTypeId", "DeviceTypeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c36fc79-b1d3-45ea-bc6a-93258d32d9ea", "AQAAAAIAAYagAAAAEFlpYOS4NOybCMQbhgTNINmQ6sIbvGt1WOWK1Ro/dADRDIXBMeZMWy59Z+Kcu2cb/w==", "2a480235-72f7-4dec-8917-67fb251744f5" });
        }
    }
}

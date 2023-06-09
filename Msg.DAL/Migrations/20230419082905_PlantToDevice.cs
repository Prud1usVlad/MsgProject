using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PlantToDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlantId",
                table: "Devices",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c36fc79-b1d3-45ea-bc6a-93258d32d9ea", "AQAAAAIAAYagAAAAEFlpYOS4NOybCMQbhgTNINmQ6sIbvGt1WOWK1Ro/dADRDIXBMeZMWy59Z+Kcu2cb/w==", "2a480235-72f7-4dec-8917-67fb251744f5" });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PlantId",
                table: "Devices",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Plants_PlantId",
                table: "Devices",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Plants_PlantId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_PlantId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Devices");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d407340b-d9a5-4072-9d70-751fa13dc879", "AQAAAAIAAYagAAAAEMDyIQ8PQADJPWg3fj2xIu0yS5FN6CI09BoT4cnSDQslTnZPfAmmh/5/W9jsMsoThQ==", "283a4bf5-0d6f-45a9-9679-594b3fde3982" });
        }
    }
}

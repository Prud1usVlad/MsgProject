using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "PackTypes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "DeviceTypes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "301124cc-15f4-4440-bada-ac1912928b03", "AQAAAAIAAYagAAAAEF7RuOln+j2b3JsJ9h9uW+5DBtJaLH8kdJLvYz1y1nHTAUQ+R4AbwqiHGiBLMkhLaQ==", "33cde5d3-6c13-40e3-bde1-a8b363ed4f6b" });

            migrationBuilder.UpdateData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Image",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PackTypes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "DeviceTypes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e4e639e-e733-4a04-ba4d-f1db470a1dbe", "AQAAAAIAAYagAAAAEPAyI5k3RzgSpj1EGvuFYUIYOt4EpG3phgUMfEivdONMxjZxbke44CIcLLrCItnj8Q==", "7a657e80-97d3-4d85-a4f0-8954093e7189" });
        }
    }
}

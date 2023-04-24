using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDataPieces_Warnings_WarningId",
                table: "DeviceDataPieces");

            migrationBuilder.AlterColumn<long>(
                name: "WarningId",
                table: "DeviceDataPieces",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "290bdc5d-603d-44eb-94e0-e1d9ab84978e", "AQAAAAIAAYagAAAAEPBHT4ftztHuTnrmqdGf5F/oKskXvvgq2Zw+e4KNec1E/6feLMOII93S6oe8Di6lIQ==", "1a2c1ca7-5ac4-476e-99bc-ea4aa8592a95" });

            migrationBuilder.UpdateData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateBought",
                value: new DateOnly(2023, 4, 23));

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDataPieces_Warnings_WarningId",
                table: "DeviceDataPieces",
                column: "WarningId",
                principalTable: "Warnings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDataPieces_Warnings_WarningId",
                table: "DeviceDataPieces");

            migrationBuilder.AlterColumn<long>(
                name: "WarningId",
                table: "DeviceDataPieces",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "301124cc-15f4-4440-bada-ac1912928b03", "AQAAAAIAAYagAAAAEF7RuOln+j2b3JsJ9h9uW+5DBtJaLH8kdJLvYz1y1nHTAUQ+R4AbwqiHGiBLMkhLaQ==", "33cde5d3-6c13-40e3-bde1-a8b363ed4f6b" });

            migrationBuilder.UpdateData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateBought",
                value: new DateOnly(2023, 4, 19));

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDataPieces_Warnings_WarningId",
                table: "DeviceDataPieces",
                column: "WarningId",
                principalTable: "Warnings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

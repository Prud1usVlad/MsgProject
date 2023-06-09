using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SomeNewSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "affb1710-b456-4b21-8a0d-f0b20d56ced6", "AQAAAAIAAYagAAAAEKrniSs6dZQLkTFwXPDwrTaiP8yuZ+BbLEqXeID3h58GX+e9JkYWuUkQRHOfGoM8DQ==", "6f0ce148-5b43-4a6b-a655-817c41490c7c" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", 0, "2f1e94eb-5d9f-49c4-913e-b5c99c5349f3", "test@gmail.com", false, false, null, "TEST@GMAIL.COM", "TEST", "AQAAAAIAAYagAAAAELBnGL1iPUXhohq4PuTEJgGKm34DHLLdUibV8J7Mu5vVdPgEqf8714C2ExWOphnFTA==", null, false, "f807b6ad-f5e6-419d-926a-5aaedab40565", false, "test" });

            migrationBuilder.UpdateData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateBought",
                value: new DateOnly(2023, 5, 30));

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Amount", "DeviceTypeId" },
                values: new object[] { 3, 2L });

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Amount", "DeviceTypeId" },
                values: new object[] { 2, 3L });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "fab4fac1-c546-41de-aebc-a14da6895711" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "fab4fac1-c546-41de-aebc-a14da6895711" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7423fa1-5725-41bf-93fd-b0bc47dcc6a2", "AQAAAAIAAYagAAAAENCyylhgQzzf5T6UTEA+LPDMfeh6h+iaUlLuZlHgtT9ru29iaI67OIAw27I9ydRHsQ==", "a3f1644d-e577-491f-8eee-34bc7a7d5d91" });

            migrationBuilder.UpdateData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateBought",
                value: new DateOnly(2023, 5, 23));

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Amount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Amount",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Amount",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Amount", "DeviceTypeId" },
                values: new object[] { 10, 1L });

            migrationBuilder.UpdateData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Amount", "DeviceTypeId" },
                values: new object[] { 10, 2L });

            migrationBuilder.InsertData(
                table: "DevicesInPacks",
                columns: new[] { "Id", "Amount", "DeviceTypeId", "PackTypeId" },
                values: new object[] { 9L, 4, 3L, 4L });
        }
    }
}

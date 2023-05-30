using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e491891-2e19-4808-a7ef-494f1810af29", "AQAAAAIAAYagAAAAEPxiWsfl+yA6+TsEoDLfEfi2gXAbTFPZNM5GFLDuHRvJqb7QeDyq47CDzcDL4TsD/Q==", "6deb6912-18e1-4cdd-8790-cc313d33b679" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "380c107a-a618-420f-8bb1-b3b0d406670e", "AQAAAAIAAYagAAAAEJ6vXnUSWYfnuugOhDiTfb+1GgafyC7FKmz1xXL0f4+8jrs+YhobBTCSodCPZYNnug==", "e7bde8c9-bd42-4bfa-bead-960354a00ad1" });

            migrationBuilder.InsertData(
                table: "DevicePacks",
                columns: new[] { "Id", "DateBought", "PackTypeId", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateOnly(2023, 5, 22), 1L, "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 3L, new DateOnly(2023, 5, 24), 1L, "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 4L, new DateOnly(2023, 5, 27), 3L, "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 5L, new DateOnly(2023, 5, 28), 2L, "fab4fac1-c546-41de-aebc-a14da6895711" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Email", "PackTypeId", "Phone", "Processed", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateOnly(2023, 5, 22), "test@gmail.com", 1L, "1111111111", true, null },
                    { 2L, new DateOnly(2023, 5, 24), "test@gmail.com", 1L, "1111111111", true, null },
                    { 3L, new DateOnly(2023, 5, 27), "test@gmail.com", 2L, "1111111111", false, null },
                    { 4L, new DateOnly(2023, 5, 27), "test@gmail.com", 3L, "1111111111", true, null },
                    { 5L, new DateOnly(2023, 5, 27), "test@gmail.com", 4L, "1111111111", false, null },
                    { 6L, new DateOnly(2023, 5, 28), "test@gmail.com", 2L, "1111111111", true, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "affb1710-b456-4b21-8a0d-f0b20d56ced6", "AQAAAAIAAYagAAAAEKrniSs6dZQLkTFwXPDwrTaiP8yuZ+BbLEqXeID3h58GX+e9JkYWuUkQRHOfGoM8DQ==", "6f0ce148-5b43-4a6b-a655-817c41490c7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f1e94eb-5d9f-49c4-913e-b5c99c5349f3", "AQAAAAIAAYagAAAAELBnGL1iPUXhohq4PuTEJgGKm34DHLLdUibV8J7Mu5vVdPgEqf8714C2ExWOphnFTA==", "f807b6ad-f5e6-419d-926a-5aaedab40565" });
        }
    }
}

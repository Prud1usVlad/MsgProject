using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RealNewSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackId",
                table: "Devices");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e4e639e-e733-4a04-ba4d-f1db470a1dbe", "AQAAAAIAAYagAAAAEPAyI5k3RzgSpj1EGvuFYUIYOt4EpG3phgUMfEivdONMxjZxbke44CIcLLrCItnj8Q==", "7a657e80-97d3-4d85-a4f0-8954093e7189" });

            migrationBuilder.InsertData(
                table: "DeviceTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "MSG Logger I is a smart device that analyzes substrates and provides detailed information about their composition, helping users make informed decisions about their usage and handling.", "MSG Logger I" },
                    { 2L, "MSG Logger II is a smart device that designed to analyze the substrate, providing detailed information about its composition and properties, allowing for better decision-making and optimization of processes.", "MSG Logger II" },
                    { 3L, "MSG Logger III is a substrate analysis smart device uses sensors to provide real-time data on the quality and composition of soil or other substrates for optimized plant growth.", "MSG Logger III" }
                });

            migrationBuilder.InsertData(
                table: "PackTypes",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "This tiny bundle of smart devices is a collection of small, interconnected devices that work together to provide various functionalities such as monitoring, tracking, and controlling. Despite their small size, they offer great convenience and versatility for a wide range of applications.", "Basic bundle", 10.0 },
                    { 2L, "The medium-sized bundle of smart devices includes a variety of tools that can be used for monitoring and controlling various aspects of a project. These devices can communicate with each other and with a central hub, providing real-time data and insights for project managers.", "Mid bundle", 22.0 },
                    { 3L, "An advanced bundle of smart devices consists of highly sophisticated and interconnected devices that utilize cutting-edge technologies to enhance automation, productivity, and efficiency in various industries. These devices can be customized to fit specific needs and can communicate and exchange data with each other, leading to optimized performance and decision-making.", "Advansed bundle", 45.0 },
                    { 4L, "The professional bundle of smart devices is a comprehensive set of tools designed for advanced data collection and analysis. It includes high-quality sensors, data loggers, and software for precise and accurate measurement in various industries, including scientific research, engineering, and manufacturing.", "Professional bundle", 99.0 }
                });

            migrationBuilder.InsertData(
                table: "DevicePacks",
                columns: new[] { "Id", "DateBought", "PackTypeId", "UserId" },
                values: new object[] { 1L, new DateOnly(2023, 4, 19), 1L, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "DevicesInPacks",
                columns: new[] { "Id", "Amount", "DeviceTypeId", "PackTypeId" },
                values: new object[,]
                {
                    { 1L, 4, 1L, 1L },
                    { 2L, 6, 1L, 2L },
                    { 3L, 2, 2L, 2L },
                    { 4L, 6, 1L, 3L },
                    { 5L, 5, 2L, 3L },
                    { 6L, 2, 3L, 3L },
                    { 7L, 10, 1L, 4L },
                    { 8L, 10, 2L, 4L },
                    { 9L, 4, 3L, 4L }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DevicePackId", "DeviceTypeId", "PlantId" },
                values: new object[] { 1L, 1L, 1L, 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "DevicesInPacks",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<long>(
                name: "PackId",
                table: "Devices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df20681b-e31d-4d57-bbdb-43a522d7695c", "AQAAAAIAAYagAAAAED8whPEqNxi6a6eK36eaLSXIJCzp6kcPzXZwQEZGbWkxM/4Q7vRZcjnqwXnp4l+P7A==", "d432d47d-18fa-4f7a-9a28-f20cb9a390be" });
        }
    }
}

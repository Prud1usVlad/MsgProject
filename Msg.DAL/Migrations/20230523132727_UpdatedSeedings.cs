using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7423fa1-5725-41bf-93fd-b0bc47dcc6a2", "AQAAAAIAAYagAAAAENCyylhgQzzf5T6UTEA+LPDMfeh6h+iaUlLuZlHgtT9ru29iaI67OIAw27I9ydRHsQ==", "a3f1644d-e577-491f-8eee-34bc7a7d5d91" });

            migrationBuilder.InsertData(
                table: "DeviceDataPieces",
                columns: new[] { "Id", "DataPieceId", "Date", "DeviceId", "Value", "WarningId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateOnly(2023, 5, 2), 1L, 6.2000000000000002, null },
                    { 2L, 2L, new DateOnly(2023, 5, 2), 1L, 0.82999999999999996, null },
                    { 3L, 3L, new DateOnly(2023, 5, 2), 1L, 42.0, null },
                    { 4L, 1L, new DateOnly(2023, 5, 3), 1L, 6.2300000000000004, null },
                    { 5L, 2L, new DateOnly(2023, 5, 3), 1L, 0.84999999999999998, null },
                    { 6L, 3L, new DateOnly(2023, 5, 3), 1L, 42.0, null },
                    { 7L, 1L, new DateOnly(2023, 5, 4), 1L, 6.2400000000000002, null },
                    { 8L, 2L, new DateOnly(2023, 5, 4), 1L, 0.82999999999999996, null },
                    { 9L, 3L, new DateOnly(2023, 5, 4), 1L, 42.0, null },
                    { 10L, 1L, new DateOnly(2023, 5, 5), 1L, 6.2000000000000002, null },
                    { 11L, 2L, new DateOnly(2023, 5, 5), 1L, 0.85999999999999999, null },
                    { 12L, 3L, new DateOnly(2023, 5, 5), 1L, 43.0, null },
                    { 13L, 1L, new DateOnly(2023, 5, 6), 1L, 6.2000000000000002, null },
                    { 14L, 2L, new DateOnly(2023, 5, 6), 1L, 0.87, null },
                    { 15L, 3L, new DateOnly(2023, 5, 6), 1L, 43.0, null },
                    { 16L, 1L, new DateOnly(2023, 5, 7), 1L, 6.2000000000000002, null },
                    { 17L, 2L, new DateOnly(2023, 5, 7), 1L, 0.82999999999999996, null },
                    { 18L, 3L, new DateOnly(2023, 5, 7), 1L, 42.0, null },
                    { 19L, 1L, new DateOnly(2023, 5, 8), 1L, 6.2999999999999998, null },
                    { 20L, 2L, new DateOnly(2023, 5, 8), 1L, 0.88, null },
                    { 21L, 3L, new DateOnly(2023, 5, 8), 1L, 44.0, null },
                    { 22L, 1L, new DateOnly(2023, 5, 9), 1L, 6.3399999999999999, null },
                    { 23L, 2L, new DateOnly(2023, 5, 9), 1L, 0.88800000000000001, null },
                    { 24L, 3L, new DateOnly(2023, 5, 9), 1L, 44.0, null },
                    { 25L, 1L, new DateOnly(2023, 5, 10), 1L, 6.3799999999999999, null },
                    { 26L, 2L, new DateOnly(2023, 5, 10), 1L, 0.86699999999999999, null },
                    { 27L, 3L, new DateOnly(2023, 5, 10), 1L, 46.0, null },
                    { 37L, 1L, new DateOnly(2023, 5, 14), 1L, 6.4000000000000004, null },
                    { 38L, 2L, new DateOnly(2023, 5, 14), 1L, 0.90000000000000002, null },
                    { 39L, 3L, new DateOnly(2023, 5, 14), 1L, 45.0, null },
                    { 40L, 1L, new DateOnly(2023, 5, 15), 1L, 6.2999999999999998, null },
                    { 41L, 2L, new DateOnly(2023, 5, 15), 1L, 0.91000000000000003, null },
                    { 42L, 3L, new DateOnly(2023, 5, 15), 1L, 45.0, null },
                    { 43L, 1L, new DateOnly(2023, 5, 16), 1L, 6.2000000000000002, null },
                    { 44L, 2L, new DateOnly(2023, 5, 16), 1L, 0.91100000000000003, null },
                    { 45L, 3L, new DateOnly(2023, 5, 16), 1L, 47.0, null },
                    { 46L, 1L, new DateOnly(2023, 5, 17), 1L, 6.21, null },
                    { 47L, 2L, new DateOnly(2023, 5, 17), 1L, 0.90500000000000003, null },
                    { 48L, 3L, new DateOnly(2023, 5, 17), 1L, 46.0, null },
                    { 49L, 1L, new DateOnly(2023, 5, 18), 1L, 6.2110000000000003, null },
                    { 50L, 2L, new DateOnly(2023, 5, 18), 1L, 0.89000000000000001, null },
                    { 51L, 3L, new DateOnly(2023, 5, 18), 1L, 45.0, null },
                    { 52L, 1L, new DateOnly(2023, 5, 19), 1L, 6.1799999999999997, null },
                    { 53L, 2L, new DateOnly(2023, 5, 19), 1L, 0.89800000000000002, null },
                    { 54L, 3L, new DateOnly(2023, 5, 19), 1L, 47.0, null },
                    { 55L, 1L, new DateOnly(2023, 5, 20), 1L, 6.1799999999999997, null },
                    { 56L, 2L, new DateOnly(2023, 5, 20), 1L, 0.90100000000000002, null },
                    { 57L, 3L, new DateOnly(2023, 5, 20), 1L, 43.0, null },
                    { 58L, 1L, new DateOnly(2023, 5, 21), 1L, 6.1699999999999999, null },
                    { 59L, 2L, new DateOnly(2023, 5, 21), 1L, 0.87, null },
                    { 60L, 3L, new DateOnly(2023, 5, 21), 1L, 44.0, null },
                    { 61L, 1L, new DateOnly(2023, 5, 22), 1L, 6.1900000000000004, null },
                    { 62L, 2L, new DateOnly(2023, 5, 22), 1L, 0.86399999999999999, null },
                    { 63L, 3L, new DateOnly(2023, 5, 22), 1L, 45.0, null },
                    { 64L, 1L, new DateOnly(2023, 5, 23), 1L, 6.2000000000000002, null },
                    { 65L, 2L, new DateOnly(2023, 5, 23), 1L, 0.86099999999999999, null },
                    { 66L, 3L, new DateOnly(2023, 5, 23), 1L, 44.0, null }
                });

            migrationBuilder.UpdateData(
                table: "DevicePacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateBought",
                value: new DateOnly(2023, 5, 23));

            migrationBuilder.UpdateData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Image",
                value: "https://s.alicdn.com/@sc04/kf/Hf3c0c4b0bc524290a994f996fdc37989K.jpg_300x300.jpg");

            migrationBuilder.UpdateData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Image",
                value: "https://s.alicdn.com/@sc04/kf/Hf3c0c4b0bc524290a994f996fdc37989K.jpg_300x300.jpg");

            migrationBuilder.UpdateData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Image",
                value: "https://s.alicdn.com/@sc04/kf/Hf3c0c4b0bc524290a994f996fdc37989K.jpg_300x300.jpg");

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Image",
                value: "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053");

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Image",
                value: "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053");

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Image",
                value: "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053");

            migrationBuilder.UpdateData(
                table: "PackTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Image",
                value: "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053");

            migrationBuilder.UpdateData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 3L, 1L },
                column: "Value",
                value: 45.0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PhotoUrl",
                value: "https://cms.lowimpact.org/wp-content/uploads/2sprouting.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PhotoUrl",
                value: "https://cdn.shopify.com/s/files/1/2404/9387/products/image_671dd898-1e92-4944-a414-cfc6bcdc32f4_1024x1024@2x.jpg?v=1642634342");

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Description", "Name", "PhotoUrl" },
                values: new object[] { 3L, "Regular beetroot", "Beetroot", "https://cdn.shopify.com/s/files/1/0273/5551/2875/products/Picture4_900x.png?v=1592058144" });

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PhotoUrl",
                value: "https://leto.ua/img/uploads/premed/1643110922_10432f5562ba003d1b82_thumb.png");

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PhotoUrl",
                value: "https://content.rozetka.com.ua/goods/images/big/176571065.jpg");

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PhotoUrl",
                value: "https://cdn.27.ua/799/f5/e5/1373669_3.jpeg");

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 4L,
                column: "PhotoUrl",
                value: "https://svitroslyn.ua/upload/iblock/555/555e0ae93baa97d7931bdd1d689596b3.jpg");

            migrationBuilder.InsertData(
                table: "Warnings",
                columns: new[] { "Id", "IsSolved" },
                values: new object[,]
                {
                    { 1L, false },
                    { 2L, false },
                    { 3L, false }
                });

            migrationBuilder.InsertData(
                table: "DeviceDataPieces",
                columns: new[] { "Id", "DataPieceId", "Date", "DeviceId", "Value", "WarningId" },
                values: new object[,]
                {
                    { 28L, 1L, new DateOnly(2023, 5, 11), 1L, 6.4500000000000002, 1L },
                    { 29L, 2L, new DateOnly(2023, 5, 11), 1L, 0.86399999999999999, 1L },
                    { 30L, 3L, new DateOnly(2023, 5, 11), 1L, 42.0, 1L },
                    { 31L, 1L, new DateOnly(2023, 5, 12), 1L, 6.5999999999999996, 2L },
                    { 32L, 2L, new DateOnly(2023, 5, 12), 1L, 0.89000000000000001, 2L },
                    { 33L, 3L, new DateOnly(2023, 5, 12), 1L, 45.0, 2L },
                    { 34L, 1L, new DateOnly(2023, 5, 13), 1L, 6.5, 3L },
                    { 35L, 2L, new DateOnly(2023, 5, 13), 1L, 0.90000000000000002, 3L },
                    { 36L, 3L, new DateOnly(2023, 5, 13), 1L, 46.0, 3L }
                });

            migrationBuilder.InsertData(
                table: "PlantDataPieces",
                columns: new[] { "DataPieceId", "PlantId", "Value" },
                values: new object[,]
                {
                    { 1L, 3L, 6.0999999999999996 },
                    { 2L, 3L, 1.0 },
                    { 3L, 3L, 50.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "DeviceDataPieces",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 2L, 3L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Warnings",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Warnings",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Warnings",
                keyColumn: "Id",
                keyValue: 3L);

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

            migrationBuilder.UpdateData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 3L, 1L },
                column: "Value",
                value: 35.0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 4L,
                column: "PhotoUrl",
                value: null);
        }
    }
}

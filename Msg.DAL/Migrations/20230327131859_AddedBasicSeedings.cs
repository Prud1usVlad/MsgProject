using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedBasicSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d04832b1-20d1-4d11-94bd-7826c78d150c", "AQAAAAIAAYagAAAAEE4tJB0RpyFvqM+LphhxDOpB3KHVIEOuGpWBDyfmQipF1lcRtZXmZmM0tlDSjSke/A==", "3c725f3d-7d5c-4d42-a90d-cc1400bcc0ad" });

            migrationBuilder.InsertData(
                table: "DataPieces",
                columns: new[] { "Id", "MeasureUnit", "Name" },
                values: new object[,]
                {
                    { 1L, "pH", "Acidity" },
                    { 2L, "mS cm", "Electrical Capacity" },
                    { 3L, "%", "Moisure Content" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Description", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1L, "Regular beens", "Beens", null },
                    { 2L, "Regular cucumber", "Cucumber", null }
                });

            migrationBuilder.InsertData(
                table: "Substrates",
                columns: new[] { "Id", "Description", "Name", "PhotoUrl", "Price", "Volume" },
                values: new object[,]
                {
                    { 1L, "GT1  (30%  sand  +20% organic  soil +  50% coco  coir)", "GT1", null, 4.0, 2.0 },
                    { 2L, "GT2  (75%  coco  coir  +  25% rice husk)", "GT2", null, 14.0, 5.0 },
                    { 3L, "GT3  (75% coco coir + CaO 2.2 mg/kg + acid humic 0.41%)", "GT3", null, 13.99, 3.5 },
                    { 4L, "GT4  (75% white sphagnum peat  +25% vermiculite (size  4–6  mm))", "GT4", null, 18.0, 6.0 }
                });

            migrationBuilder.InsertData(
                table: "DataLabelDataPiece",
                columns: new[] { "DataLabelId", "DataPieceId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 1L, 3L },
                    { 2L, 1L },
                    { 2L, 2L },
                    { 2L, 3L },
                    { 3L, 1L },
                    { 3L, 2L },
                    { 3L, 3L },
                    { 4L, 1L },
                    { 4L, 2L },
                    { 4L, 3L }
                });

            migrationBuilder.InsertData(
                table: "PlantDataPieces",
                columns: new[] { "DataPieceId", "PlantId", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, 6.0 },
                    { 2L, 1L, 0.90000000000000002 },
                    { 3L, 1L, 35.0 },
                    { 1L, 2L, 6.2999999999999998 },
                    { 2L, 2L, 0.69999999999999996 },
                    { 3L, 2L, 48.0 }
                });

            migrationBuilder.InsertData(
                table: "SubstrateDataPieces",
                columns: new[] { "DataPieceId", "SubstrateId", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, 6.2000000000000002 },
                    { 2L, 1L, 1.3999999999999999 },
                    { 3L, 1L, 48.0 },
                    { 1L, 2L, 6.0 },
                    { 2L, 2L, 0.40000000000000002 },
                    { 3L, 2L, 38.0 },
                    { 1L, 3L, 6.5 },
                    { 2L, 3L, 0.80000000000000004 },
                    { 3L, 3L, 55.0 },
                    { 1L, 4L, 6.2000000000000002 },
                    { 2L, 4L, 0.59999999999999998 },
                    { 3L, 4L, 41.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 2L, 3L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 3L, 2L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 4L, 2L });

            migrationBuilder.DeleteData(
                table: "DataLabelDataPiece",
                keyColumns: new[] { "DataLabelId", "DataPieceId" },
                keyValues: new object[] { 4L, 3L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "PlantDataPieces",
                keyColumns: new[] { "DataPieceId", "PlantId" },
                keyValues: new object[] { 3L, 2L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 3L, 2L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 2L, 3L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 1L, 4L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 2L, 4L });

            migrationBuilder.DeleteData(
                table: "SubstrateDataPieces",
                keyColumns: new[] { "DataPieceId", "SubstrateId" },
                keyValues: new object[] { 3L, 4L });

            migrationBuilder.DeleteData(
                table: "DataPieces",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DataPieces",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DataPieces",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Substrates",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "127e1661-1c5c-433b-841c-e74963c0a48a", "AQAAAAIAAYagAAAAEG2xklkRUZ0HWWPSKscoalFcJNug/GIJf6W5Jg4/Zkdt6GJ0WiM0gSn7fPINtg6FRw==", "836e4484-b0a9-4b07-a80d-9555f3f5962e" });
        }
    }
}

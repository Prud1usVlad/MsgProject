using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataPieces_DataLabels_DataLabelId",
                table: "DataPieces");

            migrationBuilder.DropIndex(
                name: "IX_DataPieces_DataLabelId",
                table: "DataPieces");

            migrationBuilder.DropColumn(
                name: "DataLabelId",
                table: "DataPieces");

            migrationBuilder.CreateTable(
                name: "DataLabelDataPiece",
                columns: table => new
                {
                    DataLabelId = table.Column<long>(type: "bigint", nullable: false),
                    DataPieceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLabelDataPiece", x => new { x.DataLabelId, x.DataPieceId });
                    table.ForeignKey(
                        name: "FK_DataLabelDataPiece_DataLabels_DataLabelId",
                        column: x => x.DataLabelId,
                        principalTable: "DataLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataLabelDataPiece_DataPieces_DataPieceId",
                        column: x => x.DataPieceId,
                        principalTable: "DataPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "127e1661-1c5c-433b-841c-e74963c0a48a", "AQAAAAIAAYagAAAAEG2xklkRUZ0HWWPSKscoalFcJNug/GIJf6W5Jg4/Zkdt6GJ0WiM0gSn7fPINtg6FRw==", "836e4484-b0a9-4b07-a80d-9555f3f5962e" });

            migrationBuilder.InsertData(
                table: "DataLabels",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1L, "PlantRequired" },
                    { 2L, "SubstrateRequired" },
                    { 3L, "OptimizingModelRequired" },
                    { 4L, "DeviceActionRequired" },
                    { 5L, "Optional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataLabelDataPiece_DataPieceId",
                table: "DataLabelDataPiece",
                column: "DataPieceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataLabelDataPiece");

            migrationBuilder.DeleteData(
                table: "DataLabels",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DataLabels",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DataLabels",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "DataLabels",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "DataLabels",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.AddColumn<long>(
                name: "DataLabelId",
                table: "DataPieces",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "763529e8-5cf8-4034-846c-1c157752fcb4", "AQAAAAIAAYagAAAAEDiQFZOuDmhCaGhF6yKS4bq3EhkRAG9W6LdsWHb1ugbMsh/bH0weAIH28G/j/k1euw==", "eb20d61c-d9b7-40ca-afa1-88a362c8f665" });

            migrationBuilder.CreateIndex(
                name: "IX_DataPieces_DataLabelId",
                table: "DataPieces",
                column: "DataLabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataPieces_DataLabels_DataLabelId",
                table: "DataPieces",
                column: "DataLabelId",
                principalTable: "DataLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

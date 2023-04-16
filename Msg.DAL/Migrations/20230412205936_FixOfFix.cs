using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixOfFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceDataPieces",
                table: "DeviceDataPieces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceDataPieces",
                table: "DeviceDataPieces",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "384001fc-6232-435e-a0fa-c4d8e053fb54", "AQAAAAIAAYagAAAAEKwDbTRU7f5E1RachQnhXYydZKFagvFp5gbAmNC+wfo076JXk421C5HmyEsmy1GPzA==", "10638171-4263-481d-a537-baee257104fc" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataPieces_DeviceId",
                table: "DeviceDataPieces",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceDataPieces",
                table: "DeviceDataPieces");

            migrationBuilder.DropIndex(
                name: "IX_DeviceDataPieces_DeviceId",
                table: "DeviceDataPieces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceDataPieces",
                table: "DeviceDataPieces",
                columns: new[] { "DeviceId", "DataPieceId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f560414-8fcb-421e-af6a-375557f5f747", "AQAAAAIAAYagAAAAED/+4orKoIwyB/BcwNsFmnA1TWN3J+cpRFO0wqQYzChTYqKAJ/qXGK3PyLClsDQfDA==", "5cd6bac1-5aac-442c-a065-f45e09f59620" });
        }
    }
}

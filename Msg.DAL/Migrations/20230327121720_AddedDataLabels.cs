using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DataLabelId",
                table: "DataPieces",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "DataLabels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLabels", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataPieces_DataLabels_DataLabelId",
                table: "DataPieces");

            migrationBuilder.DropTable(
                name: "DataLabels");

            migrationBuilder.DropIndex(
                name: "IX_DataPieces_DataLabelId",
                table: "DataPieces");

            migrationBuilder.DropColumn(
                name: "DataLabelId",
                table: "DataPieces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed52e46f-ff42-449e-bef8-714bdeca63e9", "AQAAAAIAAYagAAAAELfuxaE9RB8REb9ug3WMRSLUU/5MMD0T1UwMDL0TYfsICo+dhQ7Q1US8yhYmlfFawQ==", "14149c17-4ecb-4e76-9955-ae60dccbc35a" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class WarningAndBlend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WarningId",
                table: "DeviceDataPieces",
                type: "bigint",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Blends",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Volume = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blends_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warnings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsSolved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warnings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlendComponents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlendId = table.Column<long>(type: "bigint", nullable: false),
                    SubstrateId = table.Column<long>(type: "bigint", nullable: false),
                    Volume = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlendComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlendComponents_Blends_BlendId",
                        column: x => x.BlendId,
                        principalTable: "Blends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlendComponents_Substrates_SubstrateId",
                        column: x => x.SubstrateId,
                        principalTable: "Substrates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d407340b-d9a5-4072-9d70-751fa13dc879", "AQAAAAIAAYagAAAAEMDyIQ8PQADJPWg3fj2xIu0yS5FN6CI09BoT4cnSDQslTnZPfAmmh/5/W9jsMsoThQ==", "283a4bf5-0d6f-45a9-9679-594b3fde3982" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataPieces_WarningId",
                table: "DeviceDataPieces",
                column: "WarningId");

            migrationBuilder.CreateIndex(
                name: "IX_BlendComponents_BlendId",
                table: "BlendComponents",
                column: "BlendId");

            migrationBuilder.CreateIndex(
                name: "IX_BlendComponents_SubstrateId",
                table: "BlendComponents",
                column: "SubstrateId");

            migrationBuilder.CreateIndex(
                name: "IX_Blends_UserId",
                table: "Blends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDataPieces_Warnings_WarningId",
                table: "DeviceDataPieces",
                column: "WarningId",
                principalTable: "Warnings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDataPieces_Warnings_WarningId",
                table: "DeviceDataPieces");

            migrationBuilder.DropTable(
                name: "BlendComponents");

            migrationBuilder.DropTable(
                name: "Warnings");

            migrationBuilder.DropTable(
                name: "Blends");

            migrationBuilder.DropIndex(
                name: "IX_DeviceDataPieces_WarningId",
                table: "DeviceDataPieces");

            migrationBuilder.DropColumn(
                name: "WarningId",
                table: "DeviceDataPieces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "384001fc-6232-435e-a0fa-c4d8e053fb54", "AQAAAAIAAYagAAAAEKwDbTRU7f5E1RachQnhXYydZKFagvFp5gbAmNC+wfo076JXk421C5HmyEsmy1GPzA==", "10638171-4263-481d-a537-baee257104fc" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Msg.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Processed = table.Column<bool>(type: "boolean", nullable: false),
                    PackTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PackTypes_PackTypeId",
                        column: x => x.PackTypeId,
                        principalTable: "PackTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b0673da-deb1-4161-8f72-c426977edc17", "AQAAAAIAAYagAAAAEPqnzYGSZ4i3WOoQkpuhv9T2nYPqrmKjxYTR8KsLvrE5baKMv25u4IL6BVUXpF1VWA==", "b08317d2-2d08-4667-b137-7a51dbb6222b" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackTypeId",
                table: "Orders",
                column: "PackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d04832b1-20d1-4d11-94bd-7826c78d150c", "AQAAAAIAAYagAAAAEE4tJB0RpyFvqM+LphhxDOpB3KHVIEOuGpWBDyfmQipF1lcRtZXmZmM0tlDSjSke/A==", "3c725f3d-7d5c-4d42-a90d-cc1400bcc0ad" });
        }
    }
}

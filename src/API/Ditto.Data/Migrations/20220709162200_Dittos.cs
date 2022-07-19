using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ditto.Data.Migrations
{
    public partial class Dittos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dittos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FrecuencyTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Frecuency = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Max = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BuyedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NextOrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CalendarEventId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ExpectedPrice = table.Column<double>(type: "REAL", nullable: false),
                    RealPrice = table.Column<double>(type: "REAL", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dittos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dittos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dittos_ProductId",
                table: "Dittos",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dittos");
        }
    }
}

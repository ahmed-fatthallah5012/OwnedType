using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandABrandId = table.Column<Guid>(name: "BrandA.BrandId", type: "uniqueidentifier", nullable: false),
                    BrandA_Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandBBrandId = table.Column<Guid>(name: "BrandB.BrandId", type: "uniqueidentifier", nullable: false),
                    BrandB_Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandA_Journal_Brand.xD",
                        column: x => x.BrandABrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandB_Journal_Brand.xD",
                        column: x => x.BrandBBrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_BrandA.BrandId",
                table: "Journal",
                column: "BrandA.BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_BrandB.BrandId",
                table: "Journal",
                column: "BrandB.BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}

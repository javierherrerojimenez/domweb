using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Duties.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "duties_db");

            migrationBuilder.CreateTable(
                name: "RESOURCES",
                schema: "duties_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUTIES",
                schema: "duties_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    HourStart = table.Column<int>(nullable: false),
                    HourEnd = table.Column<int>(nullable: false),
                    NodeStart = table.Column<string>(nullable: true),
                    NodeEnd = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 1, 17, 18, 56, 46, 185, DateTimeKind.Utc).AddTicks(9605)),
                    IsNew = table.Column<bool>(nullable: false, defaultValue: false),
                    ResourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUTIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUTIES_RESOURCES_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "duties_db",
                        principalTable: "RESOURCES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DUTIES_ResourceId",
                schema: "duties_db",
                table: "DUTIES",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCES_ResourceCode",
                schema: "duties_db",
                table: "RESOURCES",
                column: "ResourceCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DUTIES",
                schema: "duties_db");

            migrationBuilder.DropTable(
                name: "RESOURCES",
                schema: "duties_db");
        }
    }
}
